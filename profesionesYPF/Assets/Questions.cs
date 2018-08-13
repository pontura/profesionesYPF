﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Questions : MonoBehaviour {

	public Color[] colors;
	public Image num;
	public Sprite[] nums;
	public Sprite[] bgs;

	public Text title;
	public Image background;
	public QuestionButtons buttons;
	public int totalQuestions = 3;

	void Start () {	
		
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.trivia);
		Events.QuestionDone += QuestionDone;

		num.sprite = nums [Data.Instance.questionID];

		string q = "";
		if (Data.Instance.questionID == 0)
			q = GetFirst ();
		else
			q = GetOhters ();
		
		title.text = q;
		title.color = colors [Data.Instance.questionID];
		background.sprite = bgs [Data.Instance.questionID];
		buttons.Init (Data.Instance.questionID);
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
	string GetFirst()
	{
		if (Data.Instance.categoryType ==  Data.categoriesTypes.TIERRA)
			return Data.Instance.texts.pregunta_1_1;
		if(Data.Instance.categoryType ==  Data.categoriesTypes.FISICA)
			return Data.Instance.texts.pregunta_2_1;
		if(Data.Instance.categoryType ==  Data.categoriesTypes.PETROLEO)
			return Data.Instance.texts.pregunta_3_1;
		else
			return Data.Instance.texts.pregunta_4_1;
	}
	string GetOhters()
	{
		string result = "";
		if (Data.Instance.categoryType == Data.categoriesTypes.TIERRA) {

			if (Data.Instance.results.y == 0) 
				result = Data.Instance.texts.pregunta_1_10;	
			else 
				result = Data.Instance.texts.pregunta_1_11;		
			
			if (Data.Instance.questionID == 2) {
				if (Data.Instance.results.y == 0 && Data.Instance.results.z == 0) 
					result = Data.Instance.texts.pregunta_1_100;
				else if (Data.Instance.results.y == 1 && Data.Instance.results.z == 0) 
					result = Data.Instance.texts.pregunta_1_110;
				else if (Data.Instance.results.y == 0 && Data.Instance.results.z == 1) 
					result = Data.Instance.texts.pregunta_1_101;
				else if (Data.Instance.results.y == 1 && Data.Instance.results.z == 1) 
					result = Data.Instance.texts.pregunta_1_111;
			}
			
		} else if (Data.Instance.categoryType == Data.categoriesTypes.FISICA) {

			if (Data.Instance.results.y == 0) 
				result = Data.Instance.texts.pregunta_2_10;	
			else 
				result = Data.Instance.texts.pregunta_2_11;		

			if (Data.Instance.questionID == 2) {
				if (Data.Instance.results.y == 0 && Data.Instance.results.z == 0) 
					result = Data.Instance.texts.pregunta_2_100;
				else if (Data.Instance.results.y == 1 && Data.Instance.results.z == 0) 
					result = Data.Instance.texts.pregunta_2_110;
				else if (Data.Instance.results.y == 0 && Data.Instance.results.z == 1) 
					result = Data.Instance.texts.pregunta_2_101;
				else if (Data.Instance.results.y == 1 && Data.Instance.results.z == 1) 
					result = Data.Instance.texts.pregunta_2_111;
			}

		} else if (Data.Instance.categoryType == Data.categoriesTypes.PETROLEO) {

			if (Data.Instance.results.y == 0) 
				result = Data.Instance.texts.pregunta_3_10;	
			else 
				result = Data.Instance.texts.pregunta_3_11;		

			if (Data.Instance.questionID == 2) {
				if (Data.Instance.results.y == 0 && Data.Instance.results.z == 0) 
					result = Data.Instance.texts.pregunta_3_100;
				else if (Data.Instance.results.y == 1 && Data.Instance.results.z == 0) 
					result = Data.Instance.texts.pregunta_3_110;
				else if (Data.Instance.results.y == 0 && Data.Instance.results.z == 1) 
					result = Data.Instance.texts.pregunta_3_101;
				else if (Data.Instance.results.y == 1 && Data.Instance.results.z == 1) 
					result = Data.Instance.texts.pregunta_3_111;
			}

		} else {

			if (Data.Instance.results.y == 0) 
				result = Data.Instance.texts.pregunta_4_10;	
			else 
				result = Data.Instance.texts.pregunta_4_11;		

			if (Data.Instance.questionID == 2) {
				if (Data.Instance.results.y == 0 && Data.Instance.results.z == 0) 
					result = Data.Instance.texts.pregunta_4_100;
				else if (Data.Instance.results.y == 1 && Data.Instance.results.z == 0) 
					result = Data.Instance.texts.pregunta_4_110;
				else if (Data.Instance.results.y == 0 && Data.Instance.results.z == 1) 
					result = Data.Instance.texts.pregunta_4_101;
				else if (Data.Instance.results.y == 1 && Data.Instance.results.z == 1) 
					result = Data.Instance.texts.pregunta_4_111;
			}

		}
		return result;
	}
}
