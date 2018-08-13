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

	public GameObject buttons2;
	public GameObject buttons3;
	public GameObject buttons4;

	void Start()
	{		
		GameObject container;
		buttons2.SetActive (false);
		buttons3.SetActive (false);
		buttons4.SetActive (false);

		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.results);

		foreach (Carrera carrera in Data.Instance.texts.carreras) {
			all.Add (carrera);
		}

		if (all.Count == 2)
			container = buttons2;
		else if (all.Count == 3)
			container = buttons3;
		else
			container = buttons4;

		container.SetActive (true);

		results_1.text = Data.Instance.texts.results_1 + (all.Count).ToString() + " " + Data.Instance.texts.results_2;
		results_2.text = Data.Instance.texts.results_3;

		int id = 0;
		foreach (ResultButton rb in container.GetComponentsInChildren<ResultButton>()) {
			rb.Init (this, all[id]);
			id++;
		}

	}
	public void OnSelected(Carrera carrera)
	{
		Data.Instance.carrera = carrera;
		Data.Instance.scenesManager.Next ();
	}
}
