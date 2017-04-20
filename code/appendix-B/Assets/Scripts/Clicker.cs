using UnityEngine;
using System.Collections;

public class Clicker {
	public bool clicked() {
		bool triggerDown = Input.anyKeyDown;

		#if UNITY_HAS_GOOGLEVR && (UNITY_ANDROID || UNITY_EDITOR)
		triggerDown |= GvrController.ClickButtonDown;
		#endif

		return triggerDown;
	}
}
