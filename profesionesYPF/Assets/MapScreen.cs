using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScreen : MonoBehaviour {

	public Text carreraNameField;
	public Text carreraNameDesc;

	void Start()
	{
		carreraNameField.text = Data.Instance.carrera.name;
		carreraNameDesc.text = Data.Instance.carrera.desc;
	}
	public void Next()
	{
		Data.Instance.scenesManager.Next ();
	}
}
