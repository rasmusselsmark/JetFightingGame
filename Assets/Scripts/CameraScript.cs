using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject Follow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var camera = this.GetComponent<Transform> ();
		var jet = Follow.GetComponent<Transform> ();

		camera.position = new Vector3 (
			jet.position.x,
			jet.position.y,
			camera.position.z
		);
	}
}
