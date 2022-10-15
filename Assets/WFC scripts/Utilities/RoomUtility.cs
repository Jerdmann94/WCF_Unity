using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using WFC_scripts.Models;
using Random = UnityEngine.Random;

namespace WFC_scripts.Utilities {
	public static class RoomUtility  {
		public static Room collapse(Room room) {
			foreach (var data in room.tileData) {
				if (data.selectedSuper != null) heuristicChecking(room,data);
			}
			
			return room;
		}

		private static void heuristicChecking(Room room, WFCTileData data) {
			foreach (var heuristic in data.selectedSuper.heuristics) {
				var rad = heuristic.radius;
				while (rad > 0) { //GETTING GRID CORDS AND CHECKING ALL 
					//LOCATIONS WITHIN GRID 
					var x = data.Cord.RoomX;
					var y = data.Cord.RoomY;
					if (x - rad >= 0) {
						//Debug.Log("Find and remove to the left");
						findAndRemove(room.tileData, x - rad, y, heuristic.type);
						
					}
					if (x+rad < room.SizeX) {
						//Debug.Log("Find and remove to the right");
						findAndRemove(room.tileData, x + rad, y, heuristic.type);
						
					}
					if (y - rad >= 0) {
						//Debug.Log("Find and remove down");
						findAndRemove(room.tileData, x, y - rad, heuristic.type);
						
					}
					if (y+rad < room.SizeY) {
						//Debug.Log("Find and remove up");
						findAndRemove(room.tileData, x, y + rad, heuristic.type);
						
					}
					rad--;
					
				}
					
			}
		}

		private static void findAndRemove(WFCTileData[,] tileData, int x, int y, WFCType type) {
			
			var superPosition = tileData[x, y].SuperPositions
				.Find(s => {
					//Debug.Log(s.myType.name + " and " + type.name);
					
					return s.myType.typeCheck(type);
				});
			
			if (superPosition!= null) {
				tileData[x, y].SuperPositions.Remove(superPosition);
				
				//Debug.Log("Removing " + superPosition + " from " +new Vector2(x,y));
			}
			else {
				//Debug.Log("super postion could not be found");
			}
		}

		public static Room createWalls(Room room) {
			throw new System.NotImplementedException();
		}

		public static Room entropy(Room room) {
			var lowestList = new List<WFCTileData>();
			var lowestEntropy = room.tileData[0,0];
			foreach (var data in room.tileData) {
				if (data.selectedSuper != null) continue;
				if (lowestEntropy.SuperPositions.Count < data.SuperPositions.Count) continue;
				lowestList.Add(data);
			}

			if (lowestList.Count >0) {
				lowestEntropy = lowestList[Random.Range(0, lowestList.Count)];
				var rand = Random.Range(0, lowestEntropy.SuperPositions.Count);
				lowestEntropy.selectedSuper = lowestEntropy.SuperPositions[rand];
			}
			else {
				foreach (var data in room.tileData) {
					if (data.selectedSuper != null) continue;
					lowestEntropy = data;
				}
				var rand = Random.Range(0, lowestEntropy.SuperPositions.Count);
				lowestEntropy.selectedSuper = lowestEntropy.SuperPositions[rand];
			}
			
			
			MapBuilder.RoomPositionsLeft++;
			//Debug.Log("room has Entropied " + MapBuilder.RoomPositionsLeft);
			return room;
		}
	}
}