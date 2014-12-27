using UnityEngine;
using System.Collections;

public class JetScript : MonoBehaviour
{
	public float Speed = 1.0f;

	public float MinSpeed = 1.0f;
	public float MaxSpeed = 20.0f;

	public GameObject BulletPrefab;
	public float fireRate = 0.1f;
	private float nextFire = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Turn
		Transform t = GetComponent<Transform> ();
		t.Rotate(0.0f, 0.0f, -Input.GetAxis ("Horizontal") * (this.Speed / 3.0f));

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

		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			FireBullet(t);
		}

		// Move the jet
		t.Translate (0.0f, this.Speed * Time.deltaTime, 0.0f);
	}

	void FireBullet(Transform transform)
	{
		this.GetComponent<AudioSource>().Play();

		Vector3 position = transform.position + (transform.rotation * new Vector3(-0.25f, 0.6f, 0.0f));
		Object bullet = Instantiate(BulletPrefab, position, transform.rotation);
		Destroy(bullet, 1.0f);

		position = transform.position + (transform.rotation * new Vector3(+0.25f, 0.6f, 0.0f));
		bullet = Instantiate(BulletPrefab, position, transform.rotation);
		Destroy(bullet, 1.0f);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Ufo") 
		{
			GetComponent<Animator>().SetTrigger("Explode");
		}
	}

	// Called by Animator Controller
	public void DestroyJet()
	{
		Destroy(this.gameObject);
	}
}
