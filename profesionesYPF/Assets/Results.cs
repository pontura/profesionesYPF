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

	public int carrera_destacada_id;

	void Start()
	{		
		
		GameObject container;
		buttons2.SetActive (false);
		buttons3.SetActive (false);
		buttons4.SetActive (false);

		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.results);

		Vector4 r = Data.Instance.results;
		string resultField = "r_" + r.x + "_" + r.y + "_" + r.z + "_" + r.w;
		print ("_____" + resultField);
		TriviaResults triviaResults = (TriviaResults)Data.Instance.texts.GetType().GetField( resultField ).GetValue(Data.Instance.texts);

		int carrera_destacada_id = triviaResults.resaltada;


		int categoria = 0;
		if (Data.Instance.categoryType == Data.categoriesTypes.TIERRA) {
			categoria = 1;
		} else if (Data.Instance.categoryType == Data.categoriesTypes.FISICA) {
			categoria = 2;
		} else if (Data.Instance.categoryType == Data.categoriesTypes.PETROLEO) {
			categoria = 3;
		} else {
			categoria = 4;
		}
		foreach (Carrera carrera in Data.Instance.texts.carreras) {
			foreach(int carreraID in triviaResults.mostrar)
				if(carrera.id == carreraID)
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


		int id = 0;

		foreach (ResultButton rb in container.GetComponentsInChildren<ResultButton>()) {
			bool isSelected = false;
			if (id >= all.Count)
				return;
			if (all[id].id == carrera_destacada_id)
				isSelected = true;
			rb.Init (this, all[id], isSelected);
			id++;
		}



//		Vector4 r = Data.Instance.results;
//		if (r.x == 1) {
//			if (r.y == 0 && r.z == 0 && r.w == 0)
//				carrera_destacada_id = (int)Data.Instance.texts.r_1_0_0_0;
//			if (r.y == 1 && r.z == 0 && r.w == 0)
//				carrera_destacada_id = (int)Data.Instance.texts.r_1_1_0_0;
//			if (r.y == 1 && r.z == 0 && r.w == 0)
//				carrera_destacada_id = (int)Data.Instance.texts.r_1_1_0_0;
//		}
//
	}
	public void OnSelected(Carrera carrera)
	{
		Data.Instance.carrera = carrera;
		Data.Instance.scenesManager.Next ();
	}
}
