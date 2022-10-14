using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace WFC_scripts.Models {
	public class Room {
		private GameObject _goTile;

		public WFCTileScript[,] TileScripts;

		public int SizeX { get; }
		public int SizeY { get; }
		private int _remainingSuperPositions;

		public Room(int x, int y, GameObject tile) {
			SizeX = x;
			TileScripts = new WFCTileScript[x,y];
			SizeY = y;
			_goTile = tile;
		}

		

		
		
		
	}
}