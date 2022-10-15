namespace WFC_scripts.Models {
	public class Coordinate {
		public int WorldX { get; }
		public int WorldY { get; }
		public int RoomX { get; }
		public int RoomY { get; }

		public Coordinate(int x, int y, int roomX, int roomY) {
			WorldX = x;
			WorldY = y;
			RoomX = roomX;
			RoomY = roomY;
		}
	}
}