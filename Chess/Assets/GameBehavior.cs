using UnityEngine;
using System.Collections;
using ChessPiece;
namespace GameBehavior{
	public class GameBehavior : MonoBehaviour {
	
		public static int GAMESIZE = 8;
	
		public Transform lights;
	
		//TODO: Movable Camera that stays above 0 angle
		public Camera camera;
	
		public GameObject spaces;

		public Color teamColor;

		public GameObject pawn;
		public GameObject rook;
		public GameObject knight;
		public GameObject bishop;
		public GameObject king;
		public GameObject queen;
	
		private static GameObject[][] gameSpaces;
	
		private static Piece[][] gamePieces;
	
		private static bool playerTurn;
	
		private static int firstClickX;
		private static int firstClickZ;
	
		private GUI firstOrSecondClick;

		// Use this for initialization
		void Start () 
		{
			firstClickX = -1;
			firstClickZ = -1;
			playerTurn = true;//TODO for other person place switch; //TODO: also switch spaces of queens for other person
	
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
						//TODO: Change color depending on team.
						GameObject tempObject;
						string tempString = "Piece"+x+","+z;
						Piece tempPiece;
						if(z==1)
						{
							tempObject = Instantiate (pawn,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new PawnPiece(tempString,tempObject,true);
						}
						else if(x==0||x==GAMESIZE-1)
						{
							tempObject = Instantiate (rook,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new RookPiece(tempString,tempObject,true);
						}
						else if(x==1||x==GAMESIZE-2)
						{
							tempObject = Instantiate (knight,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new KnightPiece(tempString,tempObject,true);
						}
						else if(x==2||x==GAMESIZE-3)
						{
							tempObject = Instantiate (bishop,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new BishopPiece(tempString,tempObject,true);
						}
						else if(x==3)
						{
							tempObject = Instantiate (queen,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new QueenPiece(tempString,tempObject,true);
						}
						else if(x==4)
						{
							tempObject = Instantiate (king,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new KingPiece(tempString,tempObject,true);
						}
						else
						{
							tempObject = Instantiate (pawn,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new PawnPiece(tempString,tempObject,true);
						}
						Renderer rend = tempPiece.getGameObject().GetComponent<Renderer>();
						rend.material.color = teamColor;
						gamePieces[x][z]=tempPiece;
					}else if(z>=GAMESIZE-2){
						GameObject tempObject;
						string tempString = "Piece"+x+","+z;
						Piece tempPiece;
						if(z==GAMESIZE-2)
						{
							tempObject = Instantiate (pawn,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new PawnPiece(tempString,tempObject,false);
						}
						else if(x==0||x==GAMESIZE-1)
						{
							tempObject = Instantiate (rook,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new RookPiece(tempString,tempObject,false);
						}
						else if(x==1||x==GAMESIZE-2)
						{
							tempObject = Instantiate (knight,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new KnightPiece(tempString,tempObject,false);
						}
						else if(x==2||x==GAMESIZE-3)
						{
							tempObject = Instantiate (bishop,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new BishopPiece(tempString,tempObject,false);
						}
						else if(x==3)
						{
							tempObject = Instantiate (queen,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new QueenPiece(tempString,tempObject,false);
						}
						else if(x==4)
						{
							tempObject = Instantiate (king,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new KingPiece(tempString,tempObject,false);
						}
						else
						{
							tempObject = Instantiate (pawn,new Vector3(x,0,z),Quaternion.identity) as GameObject;
							tempPiece = new PawnPiece(tempString,tempObject,false);
						}
						gamePieces[x][z]=tempPiece;
					}
					if(odd)
					{
						gameSpaces[x][z] = Instantiate (spaces,new Vector3(x,0,z),Quaternion.identity) as GameObject;
						gameSpaces[x][z].GetComponent<Renderer>().material.color=teamColor;
					}
					else
					{
						gameSpaces[x][z] = Instantiate (spaces,new Vector3(x,0,z),Quaternion.identity) as GameObject;
						gameSpaces[x][z].GetComponent<Renderer>().material.color=Color.white;
					}
					gameSpaces[x][z].transform.name="Space"+x+","+z;
					odd=!odd;
				}
				odd=!odd;
			}
			updateFogOfWarBoard ();
		}
		
		// Update is called once per frame
		void Update () 
		{
			if (Input.GetMouseButtonDown (0)) {
				if (playerTurn) {
					Ray ray = camera.ScreenPointToRay (Input.mousePosition);
					RaycastHit hit;
					if (Physics.Raycast (ray, out hit, 100)) {
						string nameTemp = hit.transform.gameObject.name;
						if (nameTemp.StartsWith ("Piece")) {
							int xPos;
							int zPos;
							string[] tempTwo;
							if (firstClickX == -1 && firstClickZ == -1) {
								nameTemp = nameTemp.Replace ("Piece", "");
								tempTwo = nameTemp.Split (',');
								xPos = System.Convert.ToInt32 (tempTwo [0]);
								zPos = System.Convert.ToInt32 (tempTwo [1]);
								Piece firstPiece = gamePieces [xPos] [zPos];
								firstClickX = (int)firstPiece.getGameObject ().transform.position.x;
								firstClickZ = (int)firstPiece.getGameObject ().transform.position.z;
								//gamePieces[xPos][zPos].getGameObject().SetActive(false);
								Debug.Log ("Piece Hit: x:" + tempTwo [0] + " z:" + tempTwo [1]);
							} else if (firstClickX != -1 && firstClickZ != -1) {
								nameTemp = nameTemp.Replace ("Piece", "");
								tempTwo = nameTemp.Split (',');
								xPos = System.Convert.ToInt32 (tempTwo [0]);
								zPos = System.Convert.ToInt32 (tempTwo [1]);
								Piece secondPiece = gamePieces [xPos] [zPos];
								xPos = (int)secondPiece.getGameObject ().transform.position.x;
								zPos = (int)secondPiece.getGameObject ().transform.position.z;
								bool checkedMove = checkLegalMove (xPos, zPos);
								if (checkedMove) {
									Piece tempPiece = pieceOnBoard (firstClickX, firstClickZ);
									if (tempPiece == null) {
										Debug.Log ("ERROR");
										return;
									}
									GameObject tempGO = tempPiece.getGameObject ();
									tempGO.transform.Translate (new Vector3 (xPos - firstClickX, 0, zPos - firstClickZ));
									if(tempPiece is PawnPiece && zPos == GAMESIZE-1){
										replacePawnForQueen(tempPiece,xPos,zPos);
									}
									Debug.Log ("Space Hit: x:" + tempTwo [0] + " z:" + tempTwo [1]);
									cancelFirstClick ();
									endPlayerTurn ();
								} else {
									return;
								}
								//gamePieces[xPos][zPos].getGameObject().SetActive(false);
								//Debug.Log( "Piece Hit: x:"+tempTwo[0]+" z:"+tempTwo[1] );
							}
						} else if (nameTemp.StartsWith ("Space")) {	
							if (firstClickX != -1 && firstClickZ != -1) {
								int xPos;
								int zPos;
								string[] tempTwo;
								nameTemp = nameTemp.Replace ("Space", "");
								tempTwo = nameTemp.Split (',');
								xPos = System.Convert.ToInt32 (tempTwo [0]);
								zPos = System.Convert.ToInt32 (tempTwo [1]);
								bool checkedMove = checkLegalMove (xPos, zPos);
								if (checkedMove) {
									Piece tempPiece = pieceOnBoard (firstClickX, firstClickZ);
									if (tempPiece == null) {
										Debug.Log ("ERROR");
										return;
									}
									GameObject tempGO = tempPiece.getGameObject ();
									tempGO.transform.Translate (new Vector3 (xPos - firstClickX, 0, zPos - firstClickZ));
									if(tempPiece is PawnPiece && zPos == GAMESIZE-1){
										replacePawnForQueen(tempPiece,xPos,zPos);
									}
									cancelFirstClick ();
									endPlayerTurn ();
								} else {
									return;
								}
							}
						}
					}
				}
			}
		}
		public void replacePawnForQueen(Piece tempPiece,int xPos,int zPos){
			GameObject tempGO = tempPiece.getGameObject ();
			GameObject tempObject = Instantiate (queen,new Vector3(xPos,0,zPos),Quaternion.identity) as GameObject;
			Piece tempQueen = new QueenPiece(tempPiece.name,tempObject,true);
			string queenReplaceString = tempPiece.name.Replace ("Piece", "");
			string[] queenTempString = queenReplaceString.Split (',');
			int queenX = System.Convert.ToInt32 (queenTempString [0]);
			int queenZ = System.Convert.ToInt32 (queenTempString [1]);
			Renderer rend = tempQueen.getGameObject().GetComponent<Renderer>();
			rend.material.color = teamColor;
			gamePieces[queenX][queenZ] = tempQueen;
			tempGO.transform.Translate (new Vector3 (-GAMESIZE, 0, -GAMESIZE));
			tempGO.SetActive(false);
		}
		void OnGUI () {
			// Make a background box
			GUI.Box(new Rect(10,10,100,20), "Buttons");
			
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect(20,40,100,20), "Update Board")) {
				updateFogOfWarBoard ();
			}
			
			// Make the second button.
			if(GUI.Button(new Rect(20,70,100,20), "End Turn")) {
				endPlayerTurn();
			}
			if(GUI.Button(new Rect(20,160,100,20), "ViewBoard")) {
				viewFullBoard();
			}
			if (firstClickX != -1 && firstClickZ != -1) {
				if(GUI.Button(new Rect(20,130,100,20), "Cancel First")) {
					cancelFirstClick ();
				}
				GUI.color=Color.red;
				GUI.Box(new Rect(10,100,100,20), "Second");
			} else {
				GUI.color=Color.green;
				GUI.Box(new Rect(10,100,100,20), "First");
			}
			if (playerTurn) {
				GUI.color=Color.green;
				GUI.Box(new Rect(10,190,100,20), "Your Turn");
			} else {
				GUI.color=Color.red;
				GUI.Box(new Rect(10,190,100,20), "Other Turn");
			}
			
		}
		public static bool checkLegalMove(int newX,int newZ){
			if (newX == firstClickX && newZ == firstClickZ) {
				cancelFirstClick();
				return false;
			}
			bool sameTeam = false;
			Piece firstPiece = pieceOnBoard (firstClickX, firstClickZ);
			if (firstPiece!=null&&!firstPiece.getAvailableMoves()[newX][newZ]) {
				return false;
			}
			Piece secondPiece = pieceOnBoard (newX, newZ);
			if (secondPiece != null) {
				sameTeam=secondPiece.team;
			}
			if (sameTeam) {
				return false;
			}
			
			if (!sameTeam && secondPiece != null) {
				secondPiece.getGameObject().transform.Translate(new Vector3(-10,0,-10));
				secondPiece.getGameObject().SetActive(false);//TODO: a proper implementation of deleting a piece;
			}
			return true;
		}
		public static Piece pieceOnBoard(int xPos,int zPos){
			for (int t=0; t<GAMESIZE; t++) {
				for(int u=0;u<GAMESIZE;u++){
					if(gamePieces[t][u]!=null){
						if(xPos==gamePieces[t][u].getGameObject().transform.position.x && zPos==gamePieces[t][u].getGameObject().transform.position.z){
							return gamePieces[t][u];
						}
					}
				}
			}
			return null;
		}
		public static void endPlayerTurn(){
			cancelFirstClick ();
			updateFogOfWarBoard ();
			playerTurn=!playerTurn;
			//If Pawn and hits last row, turn to queen
			//TODO:
		}
		public static void viewFullBoard(){
			for (int t=0; t<GAMESIZE; t++) {
				for(int u=0;u<GAMESIZE;u++){
					gameSpaces[t][u].SetActive(true);
					Piece foundPiece = pieceOnBoard(t,u);
					if(foundPiece!=null){
						foundPiece.getGameObject().SetActive(true);
					}
				}
			}
		}
		public static void updateFogOfWarBoard(){
				bool[][] spaces = new bool[][]{
					new bool[GAMESIZE],
					new bool[GAMESIZE],
					new bool[GAMESIZE],
					new bool[GAMESIZE],
					new bool[GAMESIZE],
					new bool[GAMESIZE],
					new bool[GAMESIZE],
					new bool[GAMESIZE]
				};
				for (int t=0; t<GAMESIZE; t++) {
					for(int u=0;u<GAMESIZE;u++){
						spaces[t][u]=false;
					}
				}
				for (int p=0; p<GAMESIZE; p++) {
					for(int q=0;q<2;q++){
						Piece tempPiece = gamePieces[p][q];
						int tempX =(int) tempPiece.getGameObject().transform.position.x;
						int tempZ = (int) tempPiece.getGameObject().transform.position.z;
						if(tempX<GAMESIZE && tempX>=0 && tempZ<GAMESIZE && tempZ>=0){
							spaces[tempX][tempZ]=true;
							bool[][] pieceSpaces = tempPiece.getAvailableMoves();
							if(pieceSpaces != null){
								for (int t=0; t<GAMESIZE; t++) {
									for(int u=0;u<GAMESIZE;u++){
										spaces[t][u]=spaces[t][u] || pieceSpaces[t][u];
									}
								}
							}
							if(tempPiece is PawnPiece){
								if (tempZ != GAMESIZE - 1) {
									if (tempX != 0) {
										spaces[tempX-1][tempZ+1]=true;
									}
									if (tempX != GAMESIZE - 1) {
										spaces[tempX+1][tempZ+1]=true;
									}
									spaces[tempX][tempZ+1]=true;
								}
							}
						}
					}
				}
				for (int t=0; t<GAMESIZE; t++) {
					for(int u=0;u<GAMESIZE;u++){
						if(spaces[t][u]==false){
							gameSpaces[t][u].SetActive(false);
							Piece foundPiece = pieceOnBoard(t,u);
							if(foundPiece!=null){
								foundPiece.getGameObject().SetActive(false);
							}
						}else{
							gameSpaces[t][u].SetActive(true);
							Piece foundPiece = pieceOnBoard(t,u);
							if(foundPiece!=null){
								foundPiece.getGameObject().SetActive(true);
							}
						}
					}
				}
				//TODO: add logic for pawn moving forward but cant take piece in front.
		}
		public static void cancelFirstClick(){
			Debug.Log("Cancel First Click");
			firstClickX=-1;
			firstClickZ=-1;
		}
	}
}
