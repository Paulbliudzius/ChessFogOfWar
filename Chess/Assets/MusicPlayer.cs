using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour {
	public int counter;
	// Use this for initialization
	void Start () {
		counter = Random.Range(0,otherClip.Length);
	}

	// Update is called once per frame
	void Update () {
	}
	public AudioClip[] otherClip; //make an arrayed variable (so you can attach more than one sound)
	void OnGUI () {
		if(GUI.Button(new Rect(20,360,100,20), "Play Song")) {
			PlaySound ();
		}
		if(GUI.Button(new Rect(20,330,100,20), "Stop Music")) {
			StopMusic ();
		}

	}
	public void StopMusic(){
		AudioSource source  = GetComponent<AudioSource>();
		source.Stop ();
	}
	// Play random sound from variable
	public void PlaySound()
	{
		//Assign random sound from variable
		AudioSource source  = GetComponent<AudioSource>();
		source.Stop ();
		source.clip = otherClip[counter];
		//AudioClip audio = otherClip[Random.Range(0,otherClip.length)];
		source.Play();
		counter++;
		if (counter >= otherClip.Length) {
			counter=0;
		}
		// Wait for the audio to have finished
		//source.Play((ulong) source.clip.length);
		
		//Now you should re-loop this function Like
	}
}
