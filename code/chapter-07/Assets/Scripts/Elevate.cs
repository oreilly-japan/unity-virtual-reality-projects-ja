using UnityEngine;
using System.Collections;

public class Elevate : MonoBehaviour {
	public float minHeight = 0.2f;
	public float maxHeight = 11.8f;
	public float velocity = 1;

	// Update is called once per frame
	void Update () {
		float y = transform.position.y;
		y += velocity * Time.deltaTime;
		if (y > maxHeight) {
			y = maxHeight;
			velocity = -velocity;
		}
		if (y < minHeight) {
			y = minHeight;
			velocity = -velocity;
		}
		transform.position = new Vector3 (transform.position.x, y, transform.position.z);
	}
}
