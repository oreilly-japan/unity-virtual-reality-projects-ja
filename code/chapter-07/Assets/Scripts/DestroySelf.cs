using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (transform.position.y < -5f) {
			Destroy (gameObject);
		}
	}
}
