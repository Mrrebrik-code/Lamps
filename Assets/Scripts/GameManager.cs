using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
	[SerializeField] private Lamp[] _lamps;
	private Lamp _currentSelectedLamp = null;

	[SerializeField] private ToggleSwitch _toggleSwitch;
	[SerializeField] private ButttonLamp _buttonLamp;

	[SerializeField] private GameObject _infoPanel;

	private void Awake()
	{
		_buttonLamp.SetStatus("Выключить");
		_toggleSwitch.OnSwitchToggle += HandlerToggleSwitch;
		_lamps.ToList().ForEach(lamp =>
		{
			lamp.OnClick += HandlerClickToLamp;
		});
		if(_currentSelectedLamp = null)
		{
			_buttonLamp.Button.interactable = false;
		}
	}
	private void HandlerToggleSwitch(bool energy)
	{
		if (energy)
		{
			_lamps.ToList().ForEach(lamp =>
			{
				if (lamp.IsLight)
				{
					lamp.LampOn();
				}
				else
				{
					lamp.LampOff();
				}
			});
		}
		else
		{
			_lamps.ToList().ForEach(lamp =>
			{
				lamp.LampOff(mock: true);
			});
		}
	}
	public void OnCurrentLamp()
	{
		if (_toggleSwitch.IsEnergy)
		{
			if (!_currentSelectedLamp.IsLight)
			{
				_currentSelectedLamp.LampOn();
				_buttonLamp.SetStatus("Выключить");
			}
			else
			{
				_currentSelectedLamp.LampOff();
				_buttonLamp.SetStatus("Включить");
			}
		}
		else
		{
			_infoPanel.SetActive(true);
			Reboot();
		}
	}
	private void HandlerClickToLamp(Lamp lamp)
	{
		_currentSelectedLamp = lamp;
		_buttonLamp.Button.interactable = true;
		if (_currentSelectedLamp.IsLight)
		{
			_buttonLamp.SetStatus("Выключить");
		}
		else
		{
			_buttonLamp.SetStatus("Включить");
		}
	}
	public void Reboot()
	{
		_lamps.ToList().ForEach(currentLamp =>
		{
			currentLamp.LampOff();
		});
		_toggleSwitch.Reboot();
		_buttonLamp.SetStatus("Выключить");
		_buttonLamp.Button.interactable = false;
		_currentSelectedLamp = null;
	}
}
