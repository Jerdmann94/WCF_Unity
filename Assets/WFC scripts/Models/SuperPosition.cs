using System.Collections.Generic;
using UnityEngine;

namespace WFC_scripts.Models {
	[CreateAssetMenu(menuName = "WFC/SuperPosition")]
	public class SuperPosition : ScriptableObject {
		public List<Heuristic> heuristics;
		public Color color;
		public WFCType myType;
		
	}
}