using System.Collections.Generic;
using UnityEngine;
using WFC_scripts.Models;

namespace WFC_scripts {
	public class WFCTileScript : MonoBehaviour {
		private List<SuperPosition> _superPositions;

		public WFCTileScript(List<SuperPosition> superPositions) {
			_superPositions = superPositions;
		}
	}
}