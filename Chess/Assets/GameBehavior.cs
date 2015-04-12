using UnityEngine;
using System.Collections;
using ChessPlayer;
using ChessPiece;

public class GameBehavior : MonoBehaviour {

	public static int GAMESIZE = 8;

	public Transform lights;

	public Camera camera;

	public GameObject white;

	public GameObject opposite;

	public GameObject pawn;
	public GameObject rook;
	public GameObject knight;
	public GameObject bishop;
	public GameObject king;
	public GameObject queen;

	//public GameObject[][] gamePieces;
	
	private GameObject[][] gameSpaces;

//	private Transform[][] gameLights;

	private Player player; 

	private Player opponent;
	
	// Use this for initialization
	void Start () {
		player = new Player ();
		opponent = new Player ();

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

		bool odd = true;
		for (int z=0; z<GAMESIZE; z++) {
			for (int x=0; x<GAMESIZE; x++) {
				if(z<2){
					GameObject tempObject;
					string tempString = "z:"+z+" x:"+x;
					Piece tempPiece;
					if(z==1)
					{
						tempObject = Instantiate (pawn,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new PawnPiece(tempString,tempObject);
					}
					else if(x==0||x==GAMESIZE-1)
					{
						tempObject = Instantiate (rook,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new RookPiece(tempString,tempObject);
					}
					else if(x==1||x==GAMESIZE-2)
					{
						tempObject = Instantiate (knight,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new KnightPiece(tempString,tempObject);
					}
					else if(x==2||x==GAMESIZE-3)
					{
						tempObject = Instantiate (bishop,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new BishopPiece(tempString,tempObject);
					}
					else if(x==3)
					{
						tempObject = Instantiate (queen,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new QueenPiece(tempString,tempObject);
					}
					else if(x==4)
					{
						tempObject = Instantiate (king,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new KingPiece(tempString,tempObject);
					}
					else
					{
						tempObject = Instantiate (pawn,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new PawnPiece(tempString,tempObject);
					}
					player.addPiece(tempPiece);
				}else if(z>=GAMESIZE-2){
					GameObject tempObject;
					string tempString = "z:"+z+" x:"+x;
					Piece tempPiece;
					if(z==GAMESIZE-2)
					{
						tempObject = Instantiate (pawn,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new PawnPiece(tempString,tempObject);
					}
					else if(x==0||x==GAMESIZE-1)
					{
						tempObject = Instantiate (rook,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new RookPiece(tempString,tempObject);
					}
					else if(x==1||x==GAMESIZE-2)
					{
						tempObject = Instantiate (knight,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new KnightPiece(tempString,tempObject);
					}
					else if(x==2||x==GAMESIZE-3)
					{
						tempObject = Instantiate (bishop,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new BishopPiece(tempString,tempObject);
					}
					else if(x==3)
					{
						tempObject = Instantiate (queen,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new QueenPiece(tempString,tempObject);
					}
					else if(x==4)
					{
						tempObject = Instantiate (king,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new KingPiece(tempString,tempObject);
					}
					else
					{
						tempObject = Instantiate (pawn,new Vector3(x,(float)0.3,z),Quaternion.identity) as GameObject;
						tempPiece = new PawnPiece(tempString,tempObject);
					}
					opponent.addPiece(tempPiece);
				}
				if(odd){
					gameSpaces[x][z] = Instantiate (opposite,new Vector3(x,0,z),Quaternion.identity) as GameObject;
				}else{
					gameSpaces[x][z] = Instantiate (white,new Vector3(x,0,z),Quaternion.identity) as GameObject;
				}
				gameSpaces[x][z].transform.name=x+","+z;
				odd=!odd;
			}
			odd=!odd;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetMouseButtonDown(0) )
		{
			Ray ray = camera.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
			
			if( Physics.Raycast( ray, out hit, 100 ) )
			{
				Debug.Log( hit.transform.gameObject.name );
			}
		}
	}
}
