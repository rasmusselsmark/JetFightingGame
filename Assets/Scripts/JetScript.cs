using UnityEngine;
using System.Collections;

public class JetScript : MonoBehaviour {
	public float Speed = 1.0f;
	public float Rotation = 0.0f;

	public float MinSpeed = 1.0f;
	public float MaxSpeed = 20.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Turn
		Transform t = GetComponent<Transform> ();
		t.Rotate(0.0f, 0.0f, -Input.GetAxis ("Horizontal") * (this.Speed / 7.0f));

		// Control speed
		this.Speed += Input.GetAxis ("Vertical");
		if (this.Speed < this.MinSpeed)
		{
			this.Speed = this.MinSpeed;
		}
		if (this.Speed > this.MaxSpeed)
		{
			this.Speed = this.MaxSpeed;
		}

		// Move the jet
		t.Translate (0.0f, this.Speed * Time.deltaTime, 0.0f);
	}
}
