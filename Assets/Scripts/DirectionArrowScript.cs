﻿using UnityEngine;
using System.Collections;

public class DirectionArrowScript : MonoBehaviour
{
	public Transform Jet;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// point to closest ufo
		Transform closestUfo = LocateClosestUfo();
	
		if ((Jet == null) || (closestUfo == null))
		{
			this.GetComponent<UnityEngine.UI.Image>().enabled = false;
			return;
		}

		this.GetComponent<UnityEngine.UI.Image>().enabled = true;
		float angle = GetAngleBetweenVectors(Jet.position, closestUfo.position);

		Transform arrowTransform = this.GetComponent<Transform>();
		arrowTransform.rotation = Quaternion.Euler(0, 0, 180 - angle);
	}
	
	public float GetAngleBetweenVectors(Vector2 v1, Vector2 v2)
	{
		float rad = Mathf.Atan2(v1.x - v2.x, v1.y - v2.y);
		float degrees = rad * Mathf.Rad2Deg;
		
		return degrees;
		
	}
	private Transform LocateClosestUfo()
	{
		float shortestDistance = float.MaxValue;
		Transform closestObject = null;
		Vector2 arrowPosition = this.GetComponent<Transform>().position;

		foreach (var ufo in GameObject.FindGameObjectsWithTag("Ufo"))
		{
			Transform ufoTransform = ufo.GetComponent<Transform>();
			float distance = Vector2.Distance(arrowPosition, ufoTransform.position);

			if (distance < shortestDistance)
			{
				shortestDistance = distance;
				closestObject = ufoTransform;
			}
		}

		return closestObject;
	}
}
