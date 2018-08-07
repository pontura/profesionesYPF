﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScreen : MonoBehaviour {

	public Text carreraNameField;
	public Text carreraNameDesc;
	public Text carreraDuraction;

	void Start()
	{
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.map);

		carreraNameField.text = Data.Instance.carrera.name;
		carreraNameDesc.text = Data.Instance.carrera.desc;
		carreraDuraction.text = Data.Instance.carrera.duration;
	}
	public void Next()
	{
		Data.Instance.scenesManager.Next ();
	}
}
