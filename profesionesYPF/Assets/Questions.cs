using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Questions : MonoBehaviour {

	public int id;
	public QuestionData[] questionsData;
	public Text title;
	public Image background;
	public QuestionButtons buttons;
	public QuestionIcons icons;
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
	void QuestionDone(int selectedID)
	{
		Invoke ("PressedReady", 1.5f);
	}
	void PressedReady()
	{
		id++;
		Next ();
	}
	void Next () {
		title.text = questionsData [id].question;
		background.sprite = questionsData [id].background;
		buttons.Init (id);
		icons.Init (id);
	}
}
