using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class FireZoneScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool _isTouched = false;

	public void OnPointerUp (PointerEventData eventData)
	{
		_isTouched = false;
	}

	public void OnPointerDown (PointerEventData eventData)
	{
		_isTouched = true;
	}

	public bool IsTouched()
	{
#if MOBILE_INPUT
		return _isTouched;
#else
		return Input.GetButton("Fire1");
#endif
	}
}
