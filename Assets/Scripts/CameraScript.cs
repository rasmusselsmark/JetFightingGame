using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject Follow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		var camera = this.GetComponent<Transform> ();
		var jet = Follow.GetComponent<Transform> ();

		Vector2 forward = jet.up;

		// todo: slowly move camera to new position (otherwise gets dizzy)
		camera.position = new Vector3 (
			jet.position.x + forward.x * 3,
			jet.position.y + forward.y * 3,
			camera.position.z
		);
	}
}
