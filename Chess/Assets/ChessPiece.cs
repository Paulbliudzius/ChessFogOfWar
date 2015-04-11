using System;
using UnityEngine;

namespace ChessPiece
{
	public abstract class Piece
	{
		public GameObject pieceGO;
		public string name;
		
		public Piece (){
		}
		public abstract bool[][] getAvailableMoves ();
		
	}
	public class PawnPiece : Piece
	{
		public PawnPiece (string nameParam, GameObject pieceParam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
		}
		
		override public bool[][] getAvailableMoves()
		{
			return null; //TODO
		}
		
	}
	public class RookPiece : Piece
	{
		public RookPiece (string nameParam, GameObject pieceParam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
		}

		override public bool[][] getAvailableMoves()
		{
			return null; //TODO
		}
		
	}
	public class BishopPiece : Piece
	{
		public BishopPiece (string nameParam, GameObject pieceParam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
		}
		
		override public bool[][] getAvailableMoves()
		{
			return null; //TODO
		}
		
	}
	public class KnightPiece : Piece
	{
		public KnightPiece (string nameParam, GameObject pieceParam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
		}
		
		override public bool[][] getAvailableMoves()
		{
			return null; //TODO
		}
		
	}
	public class KingPiece : Piece
	{
		public KingPiece (string nameParam, GameObject pieceParam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
		}
		
		override public bool[][] getAvailableMoves()
		{
			return null; //TODO
		}
		
	}
	public class QueenPiece : Piece
	{
		public QueenPiece (string nameParam, GameObject pieceParam){
			//Debug.Log (nameParam + " added");
			this.pieceGO = pieceParam;
			this.name = nameParam;
			this.pieceGO.transform.name = nameParam;
		}
		
		override public bool[][] getAvailableMoves()
		{
			return null; //TODO
		}
		
	}
}


