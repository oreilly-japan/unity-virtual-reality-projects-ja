using UnityEngine;
using System.Collections;

public class Clicker {
	public bool clicked() {
#if (UNITY_ANDROID)
		return GvrController.ClickButtonDown;
#else
		return Input.anyKeyDown;
#endif
	}
}
