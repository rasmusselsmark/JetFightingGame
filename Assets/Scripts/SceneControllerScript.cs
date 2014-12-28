using UnityEngine;
using System.Collections;

public class SceneControllerScript : MonoBehaviour
{
	public static SceneControllerScript Instance = null;

	public GameObject Jet;
	public GameObject UfoPrefab;
	public UnityEngine.UI.Text LivesText;
	public UnityEngine.UI.Text ScoreText;

	private int Lives;
	private int Score;

	void Awake()
	{
		// set singleton instance
		Instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		this.Lives = 9;
		this.Score = 0;

		for (int i = 0; i < 10; i++)
		{
			GameObject ufo = Instantiate(UfoPrefab) as GameObject;
			Transform ufoTransform = ufo.GetComponent<Transform>();
			ufoTransform.position = new Vector2 (-10, -10);
			ufo.GetComponent<UfoScript>().Jet = Jet;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayerDied ()
	{
		Debug.Log("PlayerDied()");
		this.Lives--;
		this.Jet.GetComponent<Animator>().SetTrigger("Revive");
		this.Jet.GetComponent<Transform>().position = new Vector2(0, 0);
		// this.Jet.GetComponent<Transform>().position = new Vector2(0, 0);
		this.UpdateUI();
	}

	public void UpdateUI()
	{
		this.ScoreText.text = string.Format("Score: {0}", this.Score);
		this.LivesText.text = string.Format("Lives: {0}", this.Lives);
	}
}
