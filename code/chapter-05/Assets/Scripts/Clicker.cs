using UnityEngine;
using System.Collections;

public class Clicker {

	public bool clicked () {
	#if (UNITY_ANDROID || UNITY_IPHONE)
		return GvrViewer.Instance.Triggered;
	#else
		return Input.anyKeyDown;
	#endif
	}
	
}
