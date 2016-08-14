using UnityEngine;
using System.Collections;

public class GestureWalk : MonoBehaviour {
	private HeadLookWalk lookWalk;
	private HeadGesture gesture;

	// Use this for initialization
	void Start () {
		lookWalk = GetComponent<HeadLookWalk> ();
		gesture = GameObject.Find ("GameController").GetComponent<HeadGesture> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gesture.isMovingDown) {
			lookWalk.isWalking = !lookWalk.isWalking;
		}
	}
}
