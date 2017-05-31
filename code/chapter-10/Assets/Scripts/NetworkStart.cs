using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.VR;

public class NetworkStart : MonoBehaviour {
	public string hostIP = "10.0.1.14";

	void Awake () {
		VRSettings.enabled = false;

#if (UNITY_ANDROID || UNITY_IPHONE)
		VRSettings.enabled = true;
		NetworkManager net = GetComponent<NetworkManager> ();
		net.networkAddress = hostIP;
		net.StartClient ();
#endif
	}
	
}
