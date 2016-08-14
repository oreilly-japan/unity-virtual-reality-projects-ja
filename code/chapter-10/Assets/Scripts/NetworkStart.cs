using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.VR;

public class NetworkStart : MonoBehaviour {
	public GameObject oculusMain;
	public GameObject gvrMain;
	public string hostIP = "192.168.12.5";

	void Awake () {
		//VRSettings.enabled = false;

#if (UNITY_ANDROID || UNITY_IPHONE)
		oculusMain.SetActive(true);
		//gvrMain.SetActive (true);
		NetworkManager net = GetComponent<NetworkManager> ();
		net.networkAddress = hostIP;
		net.StartClient ();
#else
		oculusMain.SetActive (true);
		//gvrMain.SetActive (false);
#endif
	}
	
}
