using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class FireZoneScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
#if MOBILE_INPUT
	private bool _isTouched = false;
#endif

	public void OnPointerUp (PointerEventData eventData)
	{
#if MOBILE_INPUT
		_isTouched = false;
#endif
	}

	public void OnPointerDown (PointerEventData eventData)
	{
#if MOBILE_INPUT
		_isTouched = true;
#endif
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
