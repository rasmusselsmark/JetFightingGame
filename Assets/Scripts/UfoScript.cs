using UnityEngine;
using System.Collections;

public class UfoScript : MonoBehaviour
{
	public float Speed = 1.0f;
	public GameObject Jet;

	private Vector2 TargetPosition;
	private bool isExploded;

	// Use this for initialization
	void Start ()
	{
		FindNewTargetPosition();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Transform t = this.GetComponent<Transform>();
		t.position = Vector2.MoveTowards(t.position, this.TargetPosition, this.Speed * Time.deltaTime);

		if (Vector2.Distance(t.position, this.TargetPosition) < 0.05)
		{
			FindNewTargetPosition();
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if ((coll.gameObject.tag == "Bullet") || (coll.gameObject.tag == "Jet")) 
		{
			GetComponent<Animator>().SetTrigger("Explode");
			Destroy (coll.gameObject);
			this.isExploded = true;
			this.GetComponent<CircleCollider2D>().enabled = false;
		}
	}

	void FindNewTargetPosition()
	{
		if ((Jet == null) || (this.isExploded))
			return;

		Vector2 jetPosition = Jet.GetComponent<Transform>().position;
		this.TargetPosition = new Vector2(
			Random.Range(jetPosition.x - 30, jetPosition.x + 30),
			Random.Range(jetPosition.y - 30, jetPosition.y + 30));
	}

	// Called by animator controller
	public void PlayExplosion()
	{
		this.GetComponent<AudioSource>().Play();
	}

	public void DestroyUfo()
	{
		Destroy(this.gameObject);
	}
}
