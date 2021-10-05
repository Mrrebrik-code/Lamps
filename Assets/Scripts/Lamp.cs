using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Lamp : MonoBehaviour, IPointerClickHandler
{
	public Action<Lamp> OnClick;

	[SerializeField] private Image _lampOn;
	public bool IsLight = false;

	public void OnPointerClick(PointerEventData eventData)
	{
		OnClick?.Invoke(this);
	}
	public void LampOn()
	{
		IsLight = true;
		_lampOn.gameObject.SetActive(true);
	}
	public void LampOff(bool mock = false)
	{
		if (!mock)
		{
			IsLight = false;
			_lampOn.gameObject.SetActive(false);
		}
		else
		{
			_lampOn.gameObject.SetActive(false);
		}
		
	}
}
