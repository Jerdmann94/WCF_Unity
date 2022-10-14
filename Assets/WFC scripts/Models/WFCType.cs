using UnityEngine;

namespace WFC_scripts.Models {
	[CreateAssetMenu(menuName = "WFC/WFCType")]
	public class WFCType : ScriptableObject {


		public bool typeCheck(WFCType wfcType) {
			return wfcType.name == name;
		}
	}
}
