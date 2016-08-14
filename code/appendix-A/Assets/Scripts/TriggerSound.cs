using UnityEngine;
using System.Collections;

public class TriggerSound : MonoBehaviour {
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter (Collider other) {
		audio.Play ();
	}
}
