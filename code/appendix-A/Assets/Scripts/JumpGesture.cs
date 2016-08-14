using UnityEngine;
using System.Collections;

public class JumpGesture : MonoBehaviour {
	public bool isJump = false;
	public float jumpForce = 1000.0f;

	private float jumpRate = 1.0f;
	private float previousHeight;
	private HeadLookWalkBounce walkBounce;

	// Use this for initialization
	void Start () {
		previousHeight = Camera.main.transform.position.y;
		walkBounce = GetComponent<HeadLookWalkBounce> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (DetectJump ()) {
			walkBounce.bounceForce = jumpForce;
		}
	}

#if UNITY_ANDROID
	private Vector3 prevTouchPos;
	private bool DetectJump() {
		if (Input.GetMouseButtonDown (0)) {
			prevTouchPos = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp (0)) {
			Vector3 touchPos = Input.mousePosition;
			if ((prevTouchPos.y - touchPos.y) > 30.0f) {
				return true;
			}
		}
		return false;
	}
#else
	private bool DetectJump() {
		float height = Camera.main.transform.localPosition.y;
		float deltaHeight = height - previousHeight;
		float rate = deltaHeight / Time.deltaTime;
		previousHeight = height;
		return (rate >= jumpRate);
	}
#endif
}
