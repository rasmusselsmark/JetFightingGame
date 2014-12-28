using UnityEngine;
using System.Collections;

public class SceneControllerScript : MonoBehaviour
{
	public static SceneControllerScript Instance = null;

	public GameObject Jet;
	public GameObject UfoPrefab;
	public UnityEngine.UI.Text LivesText;
	public UnityEngine.UI.Text ScoreText;
	public UnityEngine.UI.Text LevelText;

	private int lives;
	private int score;
	private int level;
	private int numberOfEnemies;

	void Awake()
	{
		// set singleton instance, see http://unitypatterns.com/singletons/
		Instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		lives = 9;
		score = 0;
		level = 1;
		numberOfEnemies = 0;

		InstantiateUfos ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InstantiateUfos ()
	{
		StartCoroutine(ShowLevelText());
		for (int i = 0; i < level * 5; i++) {
			InstantiateUfo ();
		}
	}

	IEnumerator ShowLevelText()
	{
		LevelText.enabled = true;
		LevelText.text = string.Format("Level {0}", level);
		yield return new WaitForSeconds(3);
		LevelText.enabled = false;
	}

	void InstantiateUfo ()
	{
		GameObject ufo = Instantiate (UfoPrefab) as GameObject;
		Transform ufoTransform = ufo.GetComponent<Transform> ();
		ufoTransform.position = new Vector2 (-10, -10);

		UfoScript ufoScript = ufo.GetComponent<UfoScript>();
		ufoScript.Jet = Jet;
		ufoScript.Speed = ufoScript.Speed + level * 2;

		numberOfEnemies++;
	}

	public void DestroyUfo(GameObject ufo)
	{
		Destroy(ufo);
		numberOfEnemies--;

		if (numberOfEnemies <= 0)
		{
			level++;
			InstantiateUfos();
		}
	}

	public void PlayerDied ()
	{
		lives--;
		Jet.GetComponent<Animator>().SetTrigger("Revive");
		Jet.GetComponent<Transform>().position = new Vector2(0, 0);
		UpdateUI();
	}

	public void UfoShot()
	{
		score++;
		UpdateUI();
	}

	public void UpdateUI()
	{
		ScoreText.text = string.Format("Score: {0}", this.score);
		LivesText.text = string.Format("Lives: {0}", this.lives);
	}
}
