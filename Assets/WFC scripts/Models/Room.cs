using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace WFC_scripts.Models {
	public class Room {
		//private GameObject _goTile;
		//public WFCTileScript[,] TileScripts;
		public WFCTileData[,] tileData;
		public int SizeX { get; }
		public int SizeY { get; }
		public int PosX { get; }
		public int PosY { get; }
		

		public Room(int x, int y, GameObject tile, WFCTileData[,] tileData, int posX, int posY) {
			SizeX = x;
			SizeY = y;
			this.tileData = tileData;
			PosY = posY;
			
			PosX = posX;

			//_goTile = tile;
			//TileScripts = new WFCTileScript[x,y];
		}

		

		
		
		
	}
}