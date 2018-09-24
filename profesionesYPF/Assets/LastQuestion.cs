using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LastQuestion : MonoBehaviour {

	public GameObject help;
	public Text field1;
	public Text field2;
	public Text field3;
	public GameObject button3;

	void Start () {	

		help.SetActive (false);

		if (Data.Instance.questionID == 0) {
			Invoke ("Delayed", 2);
		} 

		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.trivia);
		Events.QuestionDone += QuestionDone;

		AddData ();
		if (field3.text == "")
			button3.SetActive (false);

	}
	void Delayed()
	{
		help.SetActive (true);
	}
	void OnDestroy () {
		Events.QuestionDone -= QuestionDone;
	}
	int selectedID;
	void QuestionDone(int selectedID)
	{
		help.SetActive (false);
		this.selectedID = selectedID;
		Invoke ("PressedReady", 0.5f);
	}
	void PressedReady()
	{		
		Data.Instance.questionID++;

		if(Data.Instance.questionID == 1)
			Data.Instance.results.y = selectedID;
		if(Data.Instance.questionID == 2)
			Data.Instance.results.z = selectedID;
		if(Data.Instance.questionID == 3)
			Data.Instance.results.w = selectedID;

		Data.Instance.scenesManager.Next ();
	}
	void AddData()
	{
		if (Data.Instance.categoryType == Data.categoriesTypes.TIERRA) {
			field1.text = Data.Instance.texts.pregunta_1_100;	
			field2.text = Data.Instance.texts.pregunta_1_101;	
			field3.text = Data.Instance.texts.pregunta_1_102;
		} else if (Data.Instance.categoryType == Data.categoriesTypes.FISICA) {
			field1.text = Data.Instance.texts.pregunta_2_100;	
			field2.text = Data.Instance.texts.pregunta_2_101;	
			field3.text = Data.Instance.texts.pregunta_2_102;

		} else if (Data.Instance.categoryType == Data.categoriesTypes.PETROLEO) {
			field1.text = Data.Instance.texts.pregunta_3_100;	
			field2.text = Data.Instance.texts.pregunta_3_101;	
			field3.text = Data.Instance.texts.pregunta_3_102;
		} else {
			field1.text = Data.Instance.texts.pregunta_4_100;	
			field2.text = Data.Instance.texts.pregunta_4_101;
			field3.text = Data.Instance.texts.pregunta_4_102;

		}
	}
}
