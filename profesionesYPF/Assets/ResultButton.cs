using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultButton : MonoBehaviour {

	public Text field;
	Carrera carrera;
	Results results;
	public Animation anim;

	public void Init(Results results, Carrera _carrera, bool isSelected)
	{
		this.carrera = _carrera;
		field.text = carrera.name.ToUpper();
		this.results = results;
		this.carrera = carrera;
		if (isSelected)
			anim.Play ("carrera_destacada");
	}
	public void OnSelected()
	{
		results.OnSelected (carrera);
	}
}
