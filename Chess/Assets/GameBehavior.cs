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

	private GameObject[][] gameSpaces;

	private Piece[][] gamePieces;

	private Player player; 

	private Player opponent;

	private int firstClickX;
	private int firstClickZ;
	
	// Use this for initialization
	void Start () 
	{
		firstClickX = -1;
		firstClickZ = -1;
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
		gamePieces=new Piece[][]{
			new Piece[GAMESIZE],
			new Piece[GAMESIZE],
			new Piece[GAMESIZE],
			new Piece[GAMESIZE],
			new Piece[GAMESIZE],
			new Piece[GAMESIZE],
			new Piece[GAMESIZE],
			new Piece[GAMESIZE]
		};

		bool odd = true;
		for (int z=0; z<GAMESIZE; z++) 
		{
			for (int x=0; x<GAMESIZE; x++) 
			{
				if(z<2){
					GameObject tempObject;
					string tempString = "Piece"+x+","+z;
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
					gamePieces[x][z]=tempPiece;
				}else if(z>=GAMESIZE-2){
					GameObject tempObject;
					string tempString = "Piece"+x+","+z;
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
					gamePieces[x][z]=tempPiece;
				}
				if(odd)
				{
					gameSpaces[x][z] = Instantiate (opposite,new Vector3(x,0,z),Quaternion.identity) as GameObject;
				}
				else
				{
					gameSpaces[x][z] = Instantiate (white,new Vector3(x,0,z),Quaternion.identity) as GameObject;
				}
				gameSpaces[x][z].transform.name="Space"+x+","+z;
				odd=!odd;
			}
			odd=!odd;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( Input.GetMouseButtonDown(0) )
		{
			Ray ray = camera.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
			
			if( Physics.Raycast( ray, out hit, 100 ) )
			{
				string nameTemp = hit.transform.gameObject.name;
				if(nameTemp.StartsWith("Piece"))
				{
					int xPos;
					int zPos;
					string[] tempTwo;
					if(this.firstClickX == -1 && this.firstClickZ == -1)
					{
						nameTemp = nameTemp.Replace("Piece","");
						tempTwo = nameTemp.Split(',');
						xPos = System.Convert.ToInt32(tempTwo[0]);
						zPos = System.Convert.ToInt32(tempTwo[1]);
						this.firstClickX=xPos;
						this.firstClickZ=zPos;
						//gamePieces[xPos][zPos].getGameObject().SetActive(false);
						Debug.Log("Piece Hit: x:"+tempTwo[0]+" z:"+tempTwo[1] );
					}
					else if(firstClickX != -1 && firstClickZ != -1)
					{
						nameTemp = nameTemp.Replace("Piece","");
						tempTwo = nameTemp.Split(',');
						xPos = System.Convert.ToInt32(tempTwo[0]);
						zPos = System.Convert.ToInt32(tempTwo[1]);
						//gamePieces[xPos][zPos].getGameObject().SetActive(false);
						//Debug.Log( "Piece Hit: x:"+tempTwo[0]+" z:"+tempTwo[1] );
					}
				}
				else if(nameTemp.StartsWith("Space"))
				{	
					if(this.firstClickX != -1 && this.firstClickZ != -1){
						int xPos;
						int zPos;
						string[] tempTwo;
						nameTemp = nameTemp.Replace("Space","");
						tempTwo = nameTemp.Split(',');
						xPos = System.Convert.ToInt32(tempTwo[0]);
						zPos = System.Convert.ToInt32(tempTwo[1]);
						GameObject tempGO = gamePieces[this.firstClickX][this.firstClickZ].getGameObject();
						tempGO.transform.Translate(new Vector3(xPos-tempGO.transform.position.x,0,zPos-tempGO.transform.position.z));
						//gameSpaces[xPos][zPos].SetActive(false);
						Debug.Log( "Space Hit: x:"+tempTwo[0]+" z:"+tempTwo[1] );
						this.firstClickX=-1;
						this.firstClickZ=-1;
					}
				}
			}
		}
	}
}
