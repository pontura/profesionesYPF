using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour {
	
	public GameObject panel_all;
	public GameObject panel_whatsapp;
	public GameObject panel_email;

	public Button whatsapp;
	public Button email;
	int id;
	public string text;

	void Start () {
		//Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.shareScreen);
		Events.OnKeyboardDone += OnKeyboardDone;
		ResetAll ();
		panel_all.SetActive (true);
	}
	void OnDestroy()
	{
		Events.OnKeyboardDone -= OnKeyboardDone;
	}
	void OnKeyboardDone(string text)
	{
		ResetAll ();
		this.text = text;
		panel_all.SetActive (true);
	}
	void ResetAll()
	{
		panel_all.SetActive (false);
		panel_whatsapp.SetActive (false);
		panel_email.SetActive (false);
	}
	public void Clicked(int id)
	{
		ResetAll ();
		this.id = id;
		switch (id) {
		case 1:
			panel_whatsapp.SetActive (true);
			break;
		case 2:
			panel_email.SetActive (true);
			break;
		}
	}
}
