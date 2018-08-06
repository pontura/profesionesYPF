using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Questions : MonoBehaviour {

	public Color[] colors;
	public QuestionData[] questionsData;
	public Text num;
	public Text title;
	public Image background;
	public QuestionButtons buttons;
	public int totalQuestions = 3;

	[Serializable]
	public class QuestionData
	{
		public string question;
		public Sprite background;
	}
	void Start () {	

		title.color = colors [Data.Instance.questionID];

		string q1;	
		string q2;
		string q3;

		print ("_" + Data.Instance.texts.pregunta_1_1);

		if (Data.Instance.categoryType == Data.categoriesTypes.TIERRA) {
			q1 = Data.Instance.texts.pregunta_1_1;
			q2 = Data.Instance.texts.pregunta_1_2;
			q3 = Data.Instance.texts.pregunta_1_3;
		} else if (Data.Instance.categoryType == Data.categoriesTypes.FISICA) {
			q1 = Data.Instance.texts.pregunta_2_1;
			q2 = Data.Instance.texts.pregunta_2_2;
			q3 = Data.Instance.texts.pregunta_2_3;
		} else if (Data.Instance.categoryType == Data.categoriesTypes.PETROLEO) {
			q1 = Data.Instance.texts.pregunta_3_1;
			q2 = Data.Instance.texts.pregunta_3_2;
			q3 = Data.Instance.texts.pregunta_3_3;
		} else {
			q1 =  Data.Instance.texts.pregunta_4_1;
			q2 =  Data.Instance.texts.pregunta_4_2;
			q3 =  Data.Instance.texts.pregunta_4_3;				
		}
		print ("q1_" + q1);
		questionsData[0].question = q1;
		questionsData[1].question = q2;
		questionsData[2].question = q3;

		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.trivia);

		Next ();
		Events.QuestionDone += QuestionDone;
	}
	void OnDestroy () {
		Events.QuestionDone -= QuestionDone;
	}
	int selectedID;
	void QuestionDone(int selectedID)
	{
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
		
		if (Data.Instance.questionID >= totalQuestions) {
			Data.Instance.scenesManager.Next ();
			return;
		}

		Data.Instance.scenesManager.Next ();
	}
	void Next () {
		num.text = "0" + (Data.Instance.questionID+1).ToString();
		title.text = questionsData [Data.Instance.questionID].question;
		background.sprite = questionsData [Data.Instance.questionID].background;
		buttons.Init (Data.Instance.questionID);
	}
}
