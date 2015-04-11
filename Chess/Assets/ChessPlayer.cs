using UnityEngine;
using System.Collections;

public class ChessPlayer : MonoBehaviour {
	int GAMESIZE = 8;
	private GameObject[] pieces;

	// Use this for initialization
	void Start () {
		pieces = new GameObject[16];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public GameObject[] getPieces(){
		return pieces;
	}
	public bool addPiece(GameObject piece){
		for (int i=0; i<16; i++) {
			if(pieces[i]==null){
				pieces[i]=piece;
				//TODO: Update everything, though maybe should be somewhere else.
				return true;
			}
		}
		return false;
	}

	public bool removePiece(int x, int z){
		for (int i=0; i<16; i++) {
			if(pieces[i]!=null){
				if(pieces[i].transform.position.x==x&&pieces[i].transform.position.z==z){
					Destroy (pieces[i]);
					pieces[i]=null;
					//TODO: Update everything, though maybe should be somewhere else.
					return true;
				}
			}
		}
		return false;
	}
	public bool[][] piecePositions(){
		return new bool[][]{
			new bool[GAMESIZE],
			new bool[GAMESIZE],
			new bool[GAMESIZE],
			new bool[GAMESIZE],
			new bool[GAMESIZE],
			new bool[GAMESIZE],
			new bool[GAMESIZE],
			new bool[GAMESIZE]
		};
	}
}
