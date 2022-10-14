using UnityEngine;
using WFC_scripts.Models;

namespace WFC_scripts.Utilities {
	public class RoomUtility  {
		public static Room collapse(Room room) {
			throw new System.NotImplementedException();
		}

		public static Room createWalls(Room room) {
			return new Room(1, 1, new GameObject());
		}

		public static Room entropy(Room room) {
			throw new System.NotImplementedException();
			
		}
	}
}