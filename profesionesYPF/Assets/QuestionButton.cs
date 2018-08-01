using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuestionButton : MonoBehaviour {

	public Image image;
	public int id;

	public Sprites[] spritesByQuestion;

	[Serializable]
	public class Sprites
	{
		public Sprite on;
		public Sprite selected;
		public Sprite unselected;
	}

	int questionId;

	void Start()
	{
		Events.QuestionDone += QuestionDone;
	}
	void OnDestroy()
	{
		Events.QuestionDone -= QuestionDone;
	}
	public void Init(int questionId) {
		this.questionId = questionId;
		image.sprite = spritesByQuestion [questionId].on;
	}
	public void Selected()
	{
		Events.QuestionDone (id);
	}
	void QuestionDone(int selectedID) {
		GetComponent<Button> ().interactable = false;
		Sprite sprite;
		if (selectedID == id)
			sprite = spritesByQuestion [questionId].selected;
		else
			sprite = spritesByQuestion [questionId].unselected;
		image.sprite = sprite;
	}
}
