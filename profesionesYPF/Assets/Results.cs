using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour {

	public ResultButton button;
	public Transform container;

	public Text results_1;
	public Text results_2;

	public List<Carrera> all;

	void Start()
	{		

		foreach (Carrera carrera in Data.Instance.texts.carreras) {
			all.Add (carrera);
		}

		results_1.text = Data.Instance.texts.results_1 + (all.Count).ToString() + " " + Data.Instance.texts.results_2;
		results_2.text = Data.Instance.texts.results_3;

		int id = 0;
		foreach (Carrera carrera in all) {
			ResultButton b = Instantiate (button);
			b.transform.SetParent (container);
			b.Init (this, carrera);
			id++;
		}

	}
	public void OnSelected(Carrera carrera)
	{
		Data.Instance.carrera = carrera;
		Data.Instance.scenesManager.Next ();
	}
}
