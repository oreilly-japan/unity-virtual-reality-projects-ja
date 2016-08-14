using UnityEngine;
using System.Collections;

public class Clicker {
	private Vector3 prevTouchPos;
	public bool clicked() {
		if (Input.GetMouseButtonDown (0)) {
			prevTouchPos = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp (0)) {
			Vector3 touchPos = Input.mousePosition;
			// 前回タッチした位置との距離を求める
			float diff = (touchPos - prevTouchPos).magnitude;
			if (diff < 30.0f) {
				// 差分がジャンプする判定値より小さければクリックとする
				return true;
			}
		}
		return false;
	}
}
