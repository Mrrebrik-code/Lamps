using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
using TMPro;

public class ToggleSwitch : MonoBehaviour
{
	public Action<bool> OnSwitchToggle;
	[SerializeField] private Image _toggle;
	[SerializeField] private TMP_Text _statusText;
	[SerializeField] private float _smoothMove = 2f;
	public bool IsEnergy = false;
	public void SwitchEnergy()
	{
		if (!IsEnergy)
		{
			OnEnergy();
		}
		else
		{
			OffEnergy();
		}
	}
	private void OnEnergy()
	{
		OnSwitchToggle?.Invoke(true);
		_statusText.text = "ON";
		IsEnergy = true;
		_toggle.rectTransform.DOAnchorPos(new Vector3(52f, 0f, 1f), _smoothMove);
	}
	private void OffEnergy()
	{
		OnSwitchToggle?.Invoke(false);
		_statusText.text = "OFF";
		IsEnergy = false;
		_toggle.rectTransform.DOAnchorPos(new Vector3(-53.1f, 0f, 1f), _smoothMove);
	}

	public void Reboot()
	{
		OffEnergy();
	}
}
