using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.VR;
using System.Collections;

public class AvatorMultiPlayer : NetworkBehaviour {

	public override void OnStartLocalPlayer() {
		if (isServer) {
			VRSettings.enabled = true;
		}

		GameObject camera = GameObject.FindWithTag ("MainCamera");
//		GameObject camera = GameObject.Find("FirstPersonCharacter");
		transform.parent = camera.transform;
		transform.localPosition = Vector3.zero;
	}
}
