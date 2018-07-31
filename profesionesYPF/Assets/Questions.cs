using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Questions : MonoBehaviour {

	public int id;
	public QuestionData[] questionsData;
	public Text num;
	public Text title;
	public Image background;
	public QuestionButtons buttons;
	public QuestionIcons icons;
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
		id++;
		if (id >= totalQuestions) {
			Data.Instance.LoadLevel ("03_Results");
			return;
		}
		Next ();
	}
	void Next () {
		num.text = "0" + (id+1).ToString();
		title.text = questionsData [id].question;
		background.sprite = questionsData [id].background;
		buttons.Init (id);
		icons.Init (id);
	}
}
