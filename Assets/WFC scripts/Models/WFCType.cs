using UnityEngine;

namespace WFC_scripts.Models {
	[CreateAssetMenu(menuName = "WFC/WFCType")]
	public class WFCType : ScriptableObject {
		public Type type;
		
		public bool typeCheck(WFCType wfcType) {
			return wfcType.type == type;
		}
	}
	
	public enum Type {
		Wall,
		Ground
	}
}