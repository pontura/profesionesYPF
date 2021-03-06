﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountriesManager : MonoBehaviour {

	public CountryButton countryButton;
	public Transform container;
	public Text field;
	public List<CountryButton> all;
	public DataConfig.CountryData data ;
	void Start () {
		Invoke ("SetOn", 0.5f);
	}
	void SetOn()
	{
		foreach (DataConfig.CountryData data in Data.Instance.dataConfig.settings.countries) {
			CountryButton button = Instantiate (countryButton, Vector2.zero, Quaternion.identity, container);
			button.Init (this, data);
			all.Add (button);
		}
		Clicked (Data.Instance.dataConfig.settings.countries[0]);
	}
	public void Clicked(DataConfig.CountryData data )
	{
		this.data = data;
		foreach (CountryButton button in all) {
			if (data == button.data)
				button.SetActiveButton (true);
			else
				button.SetActiveButton (false);
		}
		field.text = data.number.ToString();
	}
}
