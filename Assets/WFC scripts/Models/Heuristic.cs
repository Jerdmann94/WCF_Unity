﻿using UnityEngine;

namespace WFC_scripts.Models {
	[CreateAssetMenu(menuName = "WFC/Heuristic")]
	public class Heuristic : ScriptableObject {
		public WFCType type;
		public int radius;
	}
}