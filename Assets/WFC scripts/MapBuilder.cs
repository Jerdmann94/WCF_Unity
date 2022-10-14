using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using WFC_scripts;
using WFC_scripts.Models;
using WFC_scripts.Utilities;

public class MapBuilder : MonoBehaviour {
	
	private Room[] _rooms;
	
	/*-------------------------PUBLIC-------------------------------------*/
	public GameObject uiBlob;
	public MastertTileManager masterTileManager;
	public GameObject tile;
	
	void Start() {
		_rooms = new Room[1];
		_rooms[0] = new Room(5, 5,tile);
		for (int i = 0; i <_rooms.Length; i++) {
			initRoom(_rooms[i],i);
			RoomUtility.createWalls(_rooms[i]);
			
		}
	}

	private void initRoom(Room room, int roomCounter) {
		int tileCounter = 0;
		
		for (int i = 0; i < room.SizeX; i++) {
			Debug.Log(room.TileScripts);
			for (int j = 0; j < room.SizeY; j++) {
				tileCounter++;
				GameObject t = Instantiate(tile, new Vector3(i, j, 0), Quaternion.identity);
				t.name = "room " + roomCounter + "/tileCounter " + tileCounter + "/ tile";
				WFCTileScript ts = t.GetComponent<WFCTileScript>();
				ts.SuperPositions = masterTileManager.defaultTileSuperPositions;
				fillGridWithUI(ts);
				room.TileScripts[i,j] = ts;
			}
		}
	}

	private void fillGridWithUI(WFCTileScript ts) {
		for (int i = 0; i < ts.SuperPositions.Count; i++) {
			GameObject ui =Instantiate(uiBlob, ts.gameObject.transform.GetChild(0));
			Image im =ui.GetComponent<Image>();
			im.color = ts.SuperPositions[i].color;
		}
	}
}
