using System;
using UnityEngine;
using Pieces;
namespace ChessPiece
{
	public class Player
	{
		int GAMESIZE = GameBehavior.GAMESIZE;
		private Piece[] pieces;
		
		public Player (){
			this.pieces = new Piece[16];
		}
		public Piece[] getPieces(){
			return pieces;
		}
		public bool addPiece(Piece piece){
			for (int i=0; i<16; i++) {
				if(pieces[i]==null){
					pieces[i]=piece;
					//TODO: Update everything, though maybe should be somewhere else.
					return true;
				}
			}
			return false;
		}
		/*
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
		*/
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
}