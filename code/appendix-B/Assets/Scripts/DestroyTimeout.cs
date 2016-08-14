using UnityEngine;
using System.Collections;

public class DestroyTimeout : MonoBehaviour {
	public float timer = 15.0f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, timer);
	}
}
