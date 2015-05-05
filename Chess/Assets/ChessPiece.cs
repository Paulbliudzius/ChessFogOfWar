using System;
using UnityEngine;
using GameBehavior;

namespace ChessPiece
{
	public abstract class Piece
	{
		public int GAMESIZE = GameBehavior.GameBehavior.GAMESIZE;
		public GameObject pieceGO;
		public string name;
		public bool team;
		
		public Piece (){
		}
		public abstract bool[][] getAvailableMoves ();

		public GameObject getGameObject(){
			return pieceGO;
		}
		
	}
	public class PawnPiece : Piece
	{
		public PawnPiece (string nameParam, GameObject pieceParam,bool setTeam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
			this.team = setTeam;
		}
		
		override public bool[][] getAvailableMoves()
		{
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
			int x = (int) pieceGO.transform.position.x;
			int z = (int) pieceGO.transform.position.z;
			if (z != GAMESIZE - 1) {
				if (x != 0) {
					Piece frontLeft = GameBehavior.GameBehavior.pieceOnBoard(x-1,z+1);
					if(frontLeft!=null){
						if(frontLeft.team==false){
							spaces[x-1][z+1]=true;
						}
					}
				}
				if (x != GAMESIZE - 1) {
					Piece frontRight = GameBehavior.GameBehavior.pieceOnBoard(x+1,z+1);
					if(frontRight!=null){
						if(frontRight.team==false){
							spaces[x+1][z+1]=true;
						}
					}
				}
				Piece front = GameBehavior.GameBehavior.pieceOnBoard(x,z+1);
				if(front==null){
					spaces[x][z+1]=true;
				}
				if(front==null&&z==1){
					spaces[x][z+2]=true;
				}

			}
			return spaces;
		}
		
	}
	public class RookPiece : Piece
	{
		public RookPiece (string nameParam, GameObject pieceParam,bool setTeam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
			this.team = setTeam;
		}

		override public bool[][] getAvailableMoves()
		{
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
			int x = (int) pieceGO.transform.position.x;
			int z = (int) pieceGO.transform.position.z;
			Piece tempPiece;
			int counter = 1;
			while (x+counter<GAMESIZE) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x+counter,z);
				spaces[x+counter][z] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (x-counter>=0) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x-counter,z);
				spaces[x-counter][z] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (z+counter<GAMESIZE) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x,z+counter);
				spaces[x][z+counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (z-counter>=0) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x,z-counter);
				spaces[x][z-counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			return spaces;
		}
		
	}
	public class BishopPiece : Piece
	{
		public BishopPiece (string nameParam, GameObject pieceParam,bool setTeam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
			this.team = setTeam;
		}
		
		override public bool[][] getAvailableMoves()
		{
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
			int x = (int) pieceGO.transform.position.x;
			int z = (int) pieceGO.transform.position.z;
			Piece tempPiece;
			int counter = 1;
			while (x+counter<GAMESIZE&&z+counter<GAMESIZE) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x+counter,z+counter);
				spaces[x+counter][z+counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (x+counter<GAMESIZE&&z-counter>=0) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x+counter,z-counter);
				spaces[x+counter][z-counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (x-counter>=0&&z+counter<GAMESIZE) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x-counter,z+counter);
				spaces[x-counter][z+counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (x-counter>=0&&z-counter>=0) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x-counter,z-counter);
				spaces[x-counter][z-counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			return spaces;
		}
		
	}
	public class KnightPiece : Piece
	{
		public KnightPiece (string nameParam, GameObject pieceParam,bool setTeam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
			this.team = setTeam;
		}
		
		override public bool[][] getAvailableMoves()
		{
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
			int x = (int) pieceGO.transform.position.x;
			int z = (int) pieceGO.transform.position.z;
			if (x + 1 < GAMESIZE && z + 2 < GAMESIZE) {
				spaces[x+1][z+2]=true;
			}
			if (x + 2 < GAMESIZE && z + 1 < GAMESIZE) {
				spaces[x+2][z+1]=true;
			}
			if (x + 1 < GAMESIZE && z - 2 >= 0) {
				spaces[x+1][z-2]=true;
			}
			if (x + 2 < GAMESIZE && z - 1 >= 0) {
				spaces[x+2][z-1]=true;
			}
			if (x - 1 >=0 && z + 2 < GAMESIZE) {
				spaces[x-1][z+2]=true;
			}
			if (x - 2 >=0 && z + 1 < GAMESIZE) {
				spaces[x-2][z+1]=true;
			}
			if (x - 1 >=0 && z - 2 >= 0) {
				spaces[x-1][z-2]=true;
			}
			if (x - 2 >=0 && z - 1 >= 0) {
				spaces[x-2][z-1]=true;
			}
			return spaces;
		}
		
	}
	public class KingPiece : Piece
	{
		public KingPiece (string nameParam, GameObject pieceParam,bool setTeam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
			this.team = setTeam;
		}
		
		override public bool[][] getAvailableMoves()
		{
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
			int x = (int) pieceGO.transform.position.x;
			int z = (int) pieceGO.transform.position.z;
			if (x - 1 >= 0) {
				if (z - 1 >= 0) {
					spaces[x-1][z-1]=true;
				}
				if (z + 1 < GAMESIZE) {
					spaces[x-1][z+1]=true;
				}
				spaces[x-1][z]=true;
			}
			if (x + 1 < GAMESIZE) {
				if (z - 1 >= 0) {
					spaces[x+1][z-1]=true;
				}
				if (z + 1 < GAMESIZE) {
					spaces[x+1][z+1]=true;
				}
				spaces[x+1][z]=true;
			}
			if (z - 1 >= 0) {
				spaces[x][z-1]=true;
			}
			if (z + 1 < GAMESIZE) {
				spaces[x][z+1]=true;
			}
			
			return spaces;
		}
		
	}
	public class QueenPiece : Piece
	{
		public QueenPiece (string nameParam, GameObject pieceParam,bool setTeam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
			this.team = setTeam;
		}
		
		override public bool[][] getAvailableMoves()
		{
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
			int x = (int) pieceGO.transform.position.x;
			int z = (int) pieceGO.transform.position.z;
			Piece tempPiece;
			int counter = 1;
			while (x+counter<GAMESIZE&&z+counter<GAMESIZE) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x+counter,z+counter);
				spaces[x+counter][z+counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (x+counter<GAMESIZE&&z-counter>=0) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x+counter,z-counter);
				spaces[x+counter][z-counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (x-counter>=0&&z+counter<GAMESIZE) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x-counter,z+counter);
				spaces[x-counter][z+counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (x-counter>=0&&z-counter>=0) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x-counter,z-counter);
				spaces[x-counter][z-counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (x+counter<GAMESIZE) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x+counter,z);
				spaces[x+counter][z] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (x-counter>=0) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x-counter,z);
				spaces[x-counter][z] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (z+counter<GAMESIZE) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x,z+counter);
				spaces[x][z+counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			counter = 1;
			while (z-counter>=0) {
				tempPiece = GameBehavior.GameBehavior.pieceOnBoard(x,z-counter);
				spaces[x][z-counter] = true;
				if(tempPiece!=null){
					break;
				}
				counter++;
			}
			return spaces;
		}
		
	}
}


