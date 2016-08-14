using UnityEngine;
using System.Collections;

public class PopulateArtFrames : MonoBehaviour {
	public Texture[] images;

	// Use this for initialization
	void Start () {
		int imageIndex = 0;
		foreach (Transform artwork in transform) {
			GameObject art = artwork.FindChild ("Image").gameObject;
			Renderer rend = art.GetComponent<Renderer> ();
			Shader shader = Shader.Find ("Standard");
			Material mat = new Material (shader);
			mat.mainTexture = images [imageIndex];
			rend.material = mat;
			imageIndex++;
			if (imageIndex == images.Length) imageIndex = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
