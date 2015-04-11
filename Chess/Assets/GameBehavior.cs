using UnityEngine;
using System.Collections;

public class GameBehavior : MonoBehaviour {

	public int GAMESIZE = 8;

	public Transform lights;

	public GameObject white;

	public GameObject opposite;

	public GameObject pawn;

	//public GameObject[][] gamePieces;
	
	private GameObject[][] gameSpaces;

	private Transform[][] gameLights;

	private ChessPlayer owner; 

	private ChessPlayer opponent;
	
	// Use this for initialization
	void Start () {
		owner = GetComponent<ChessPlayer>();
		gameSpaces=new GameObject[][]{
			new GameObject[GAMESIZE],
			new GameObject[GAMESIZE],
			new GameObject[GAMESIZE],
			new GameObject[GAMESIZE],
			new GameObject[GAMESIZE],
			new GameObject[GAMESIZE],
			new GameObject[GAMESIZE],
			new GameObject[GAMESIZE]
		};
		gameLights=new Transform[][]{
			new Transform[GAMESIZE],
			new Transform[GAMESIZE],
			new Transform[GAMESIZE],
			new Transform[GAMESIZE],
			new Transform[GAMESIZE],
			new Transform[GAMESIZE],
			new Transform[GAMESIZE],
			new Transform[GAMESIZE]
		};
		bool odd = true;
		for (int z=0; z<GAMESIZE; z++) {
			for (int x=0; x<GAMESIZE; x++) {
				if(z<2||z>=GAMESIZE-2){
					Instantiate (pawn,new Vector3(x,(float)0.3,z),Quaternion.identity);
				}
				gameLights[x][z] = Instantiate (lights,new Vector3(x,0,z),Quaternion.identity) as Transform;
				if(odd){
					gameSpaces[x][z] = Instantiate (opposite,new Vector3(x,0,z),Quaternion.identity) as GameObject;
				}else{
					gameSpaces[x][z] = Instantiate (white,new Vector3(x,0,z),Quaternion.identity) as GameObject;
				}
				odd=!odd;
			}
			odd=!odd;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButtonDown(0)){
			Debug.Log ("Click");
		}
	}
}
