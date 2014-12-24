using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	public float Speed = 1.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
	{
		Transform t = GetComponent<Transform> ();
		t.Translate (0.0f, this.Speed * Time.deltaTime, 0.0f);
	}
}
