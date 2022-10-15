using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using WFC_scripts;
using WFC_scripts.Models;
using WFC_scripts.Utilities;
using UnityEngine.Profiling;

public class MapBuilder : MonoBehaviour {
	
	private Room[] _rooms;
	
	/*-------------------------PUBLIC-------------------------------------*/
	public GameObject uiBlob;
	public MastertTileManager masterTileManager;
	public GameObject tile;
	public static int RoomPositionsLeft;
	public int x = 10;
	public int  y = 10;
	
	public void BuildMap() {
		var sampler = CustomSampler.Create("CustomSampler");
		_rooms = new Room[1];
		_rooms[0] = new Room(x, y,tile, new WFCTileData[x,y], 0,0);
		for (int i = 0; i <_rooms.Length; i++) {
			initRoom(_rooms[i],i);
			//RoomUtility.createWalls(_rooms[i]);
			
			
		}
		sampler.Begin();
		foreach (var t in _rooms) {
			RoomPositionsLeft = 0;
			
			while (RoomPositionsLeft < t.SizeX * t.SizeY) {
				RoomUtility.entropy(t);
				RoomUtility.collapse(t);
			}
			Debug.Log(RoomPositionsLeft);
			buildGameRoom(t);
			sampler.End();
		}
		
	}

	private void initRoom(Room room, int roomCounter) {
		int tileCounter = 0;
		
		for (int i = 0; i < room.SizeX; i++) {
			for (int j = 0; j < room.SizeY; j++) {
				tileCounter++;
				room.tileData[i, j] =
					new WFCTileData(masterTileManager.defaultTileSuperPositions, 
						new Coordinate(i+room.PosX, j+room.PosY,i,j));
				
				/*GameObject t = Instantiate(tile, new Vector3(i, j, 0), Quaternion.identity);
				t.name = "room " + roomCounter + "/tileCounter " + tileCounter + "/ tile";
				WFCTileScript ts = t.GetComponent<WFCTileScript>();
				ts.init(masterTileManager.defaultTileSuperPositions);
				fillGridWithUI(ts);
				room.TileScripts[i,j] = ts;*/
			}
		}
	}

	private void buildGameRoom(Room room) {
		foreach (var tileData in room.tileData) {
			var x =tileData.Cord.WorldX;
			var y = tileData.Cord.WorldY;
			GameObject t = Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity);
			fillGridWithUI(room.tileData[tileData.Cord.RoomX,tileData.Cord.RoomY],t);
		}
		
	}
	private void fillGridWithUI(WFCTileData data,GameObject t) {
		if (data.selectedSuper == null) {
			foreach (var t1 in data.SuperPositions) {
				GameObject ui =Instantiate(uiBlob, t.transform.GetChild(0));
				Image im =ui.GetComponent<Image>();
				im.color = t1.color;
			}
		}
		else {
			GameObject ui =Instantiate(uiBlob, t.transform.GetChild(0));
			Image im =ui.GetComponent<Image>();
			im.color = data.selectedSuper.color;
		}
		
	}
}
