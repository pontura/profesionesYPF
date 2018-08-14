using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountryButton : MonoBehaviour {

	public Text field;

	public GameObject imageOn;
	public GameObject imageOff;
	public DataConfig.CountryData data;
	CountriesManager manager;

	public void Init (CountriesManager manager, DataConfig.CountryData data ) {
		this.data = data;
		this.manager = manager;
		field.text = data.name;
	}
	public void OnClicked()
	{
		manager.Clicked (data);
	}
	public void SetActiveButton(bool isOn)
	{
		imageOn.SetActive (isOn);
		imageOff.SetActive (!isOn);
	}

}
