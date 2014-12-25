using UnityEngine;
using System.Collections;

public class SceneControllerScript : MonoBehaviour
{
	public GameObject Jet;
	public GameObject UfoPrefab;

	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < 10; i++)
		{
			GameObject ufo = Instantiate(UfoPrefab) as GameObject;
			ufo.GetComponent<UfoScript>().Jet = Jet;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
