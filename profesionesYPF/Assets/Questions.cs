using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Questions : MonoBehaviour {

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
		Next ();
		Events.QuestionDone += QuestionDone;
	}
	void OnDestroy () {
		Events.QuestionDone -= QuestionDone;
	}
	void QuestionDone(int selectedID)
	{
		Invoke ("PressedReady", 1.5f);
	}
	void PressedReady()
	{		
		Data.Instance.questionID++;
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
