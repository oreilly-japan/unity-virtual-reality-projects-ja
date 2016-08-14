using UnityEngine;
using System.Collections;

public class BodyWalk : MonoBehaviour {
	private HeadLookWalk lookWalk;
	private AudioSource footsteps;
	private Transform head;
	private Transform body;

	// Use this for initialization
	void Start () {
		lookWalk = GetComponent<HeadLookWalk> ();
		footsteps = GetComponent<AudioSource> ();
		head = Camera.main.transform;
		body = transform.Find ("MeBody");
	}
	
	// Update is called once per frame
	void Update () {
		if (lookWalk.isWalking) {
			body.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, head.transform.eulerAngles.y, 0.0f));
			if (!footsteps.isPlaying) {
				footsteps.Play ();
			}
		} else { // 歩いていない
			footsteps.Stop();
		}
	}
}
