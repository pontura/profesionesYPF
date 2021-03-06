﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour {

	public Text title;

	public Text enjoyField;
	public Text acceptField;
	public Image image;
	public GameObject panel_all;
	public GameObject panel_done;
	public GameObject panel_whatsapp;
	public GameObject panel_email;
	public GameObject doneIcon;
	public GameObject hideOnKeyboard;

	public Text whatsapp_field;
	public Text email_field;

	public Button whatsapp;
	public Button email;
	int id;
	//public string text;
	bool accepted;
	public GameObject doneButton;

	void Start () {
		
		ResetWhatsapp ();
		ResetEmail ();

		Data.Instance.scenesManager.ShowSimpleNavigation ();

		title.text = Data.Instance.texts.share_instructions;
		image.material.mainTexture = Data.Instance.texture2d;
		enjoyField.text = Data.Instance.texts.enjoy;
		acceptField.text = Data.Instance.texts.accept;

		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.shareScreen);
		Events.OnKeyboardDone += OnKeyboardDone;
		Events.BackClicked += BackClicked;
		ResetAll ();
		panel_all.SetActive (true);
		doneIcon.SetActive (false);
		doneButton.SetActive (false);
	}
	void BackClicked()
	{
		ResetAll ();
	}
	void OnDestroy()
	{
		Events.OnKeyboardDone -= OnKeyboardDone;
		Events.BackClicked -= BackClicked;
	}
	void OnKeyboardDone(string text)
	{
		ResetAll ();
		if (isWhatsapp) {
			if (text == "")
				ResetWhatsapp ();
			else {
				text = GetComponent<CountriesManager> ().data.number.ToString () + text;
				whatsapp_field.text = text;
			}
		} else {
			if (text == "")
				ResetEmail ();
			else
				email_field.text = text;
		}
		hideOnKeyboard.SetActive (true);
		panel_done.SetActive (true);
		doneIcon.SetActive (false);
	}
	public void Accept()
	{
		doneIcon.SetActive (true);
		accepted = true;
		doneButton.SetActive (true);
	}
	void ResetAll()
	{
		Data.Instance.scenesManager.ShowSimpleNavigation ();
		panel_done.SetActive (false);
		//panel_all.SetActive (false);
		panel_whatsapp.SetActive (false);
		panel_email.SetActive (false);
	}
	bool isWhatsapp;
	public void Clicked(int id)
	{
		ResetAll ();
		this.id = id;
		switch (id) {
		case 1:
			isWhatsapp = true;
			//Data.Instance.scenesManager.ShowDoubleNavigationBack ();
			panel_whatsapp.SetActive (true);
			hideOnKeyboard.SetActive (false);
			break;
		case 2:
			isWhatsapp = false;
			//Data.Instance.scenesManager.ShowDoubleNavigationBack ();
			panel_email.SetActive (true);
			hideOnKeyboard.SetActive (false);
			break;
		}
	}
	public void ReOpen()
	{
		if(isWhatsapp)
			Clicked(1);
		else
			Clicked(2);
	}
	public void Done()
	{
		Data.Instance.email = email_field.text;
		Data.Instance.whatsapp = whatsapp_field.text;

		Data.Instance.SendData ();
		Data.Instance.scenesManager.Next ();
	}
	void ResetWhatsapp()
	{
		whatsapp_field.text = "WHATSAPP";
	}
	void ResetEmail()
	{
		email_field.text = "E-MAIL";
	}
}
