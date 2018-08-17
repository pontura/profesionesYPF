using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultButton : MonoBehaviour {

	public Text field;
	Carrera carrera;
	Results results;

	public void Init(Results results, Carrera _carrera)
	{
		this.carrera = _carrera;
		field.text = carrera.name.ToUpper();
		this.results = results;
		this.carrera = carrera;
	}
	public void OnSelected()
	{
		results.OnSelected (carrera);
	}
}
