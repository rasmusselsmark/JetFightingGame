using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class JetScript : MonoBehaviour
{
	public float Speed = 1.0f;

	public float MinSpeed = 1.0f;
	public float MaxSpeed = 20.0f;

	public GameObject BulletPrefab;
	public float fireRate = 0.1f;
	private float nextFire = 0.0f;

	// controls
	public UnityEngine.UI.Slider SpeedSlider;
	public FireZoneScript fireZone;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		Transform t = GetComponent<Transform> ();

		// Turn
		Turn(CrossPlatformInputManager.GetAxis("Horizontal"));

		// Control speed (using keyboard or slider)
#if MOBILE_INPUT
		this.Speed = MinSpeed + (MaxSpeed - MinSpeed) * SpeedSlider.value;
#else
		this.Speed += Input.GetAxis ("Vertical");

		// speed   slider
		//   10       1
		//    7       0.5
		//    4       0
		// f(x) = ax + b
		// f(x) = (0.5/3)x - 2/3
		SpeedSlider.value = (0.5f/3.0f) * this.Speed - (2.0f/3.0f);
#endif

		if (this.Speed < this.MinSpeed)
		{
			this.Speed = this.MinSpeed;
		}
		if (this.Speed > this.MaxSpeed)
		{
			this.Speed = this.MaxSpeed;
		}

		if (fireZone.IsTouched() && Time.time > nextFire)
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
	public void PlayExplosionAudio()
	{
		// this.GetComponent<AudioSource>().Play();
	}

	public void DestroyJet()
	{
		SceneControllerScript.Instance.PlayerDied();
	}

	// UI controller methods
	public void Turn(float horizontal)
	{
		Transform t = GetComponent<Transform> ();
		t.Rotate(0.0f, 0.0f, -horizontal * (this.Speed / 3.0f));
	}
}
