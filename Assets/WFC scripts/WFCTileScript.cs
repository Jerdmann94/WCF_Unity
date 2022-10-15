using System.Collections.Generic;
using UnityEngine;
using WFC_scripts.Models;

namespace WFC_scripts {
	public class WFCTileScript : MonoBehaviour {
		public List<SuperPosition> SuperPositions { get; private set; } = new List<SuperPosition>();

		public void init(List<SuperPosition> supers) {
			 SuperPositions = supers;
		}
	}
}