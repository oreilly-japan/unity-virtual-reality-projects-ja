using UnityEngine;
using System.Collections;

public class DisablePositionalTracking : MonoBehaviour {
	private Vector3 position;

	// Use this for initialization
	void Start () {
		position = Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = position;
	}
}
