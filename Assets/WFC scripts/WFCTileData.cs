using System.Collections.Generic;
using WFC_scripts.Models;

namespace WFC_scripts {
	public class WFCTileData {
		public Coordinate Cord { get; private set; }
		public List<SuperPosition> SuperPositions { get; private set; }

		public SuperPosition selectedSuper;
		

		public WFCTileData(List<SuperPosition> superPositions, Coordinate c) {
			SuperPositions = new List<SuperPosition>(superPositions);
			Cord = c;
		}
		
		
	}
}