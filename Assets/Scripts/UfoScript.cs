using UnityEngine;
using System.Collections;

public class UfoScript : MonoBehaviour
{
	public float Speed = 1.0f;
	public GameObject Jet;

	private Vector2 TargetPosition;

	// Use this for initialization
	void Start ()
	{
		FindNewTargetPosition();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Transform t = this.GetComponent<Transform>();
		// t.position = Vector2.MoveTowards(t.position, this.TargetPosition, this.Speed * Time.deltaTime);

		if (Vector2.Distance(t.position, this.TargetPosition) < 0.05)
		{
			FindNewTargetPosition();
		}
	}

	void FindNewTargetPosition()
	{
		Vector2 jetPosition = Jet.GetComponent<Transform>().position;
		this.TargetPosition = new Vector2(
			Random.Range(jetPosition.x - 30, jetPosition.x + 30),
			Random.Range(jetPosition.y - 30, jetPosition.y + 30));
	}
}
