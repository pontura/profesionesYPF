using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour {

	public Text title;
	public RawImage rawImage;
	public GameObject panel_all;
	public GameObject panel_whatsapp;
	public GameObject panel_email;

	public Button whatsapp;
	public Button email;
	int id;
	public string text;

	void Start () {

		title.text = Data.Instance.texts.share_instructions;
		rawImage.material.mainTexture = Data.Instance.texture2d;
		//Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.shareScreen);
		Events.OnKeyboardDone += OnKeyboardDone;
		Events.BackClicked += BackClicked;
		ResetAll ();
		panel_all.SetActive (true);
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
		this.text = text;
		panel_all.SetActive (true);
	}
	void ResetAll()
	{
		Data.Instance.scenesManager.ShowSimpleNavigation ();
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
			Data.Instance.scenesManager.ShowDoubleNavigationBack ();
			panel_whatsapp.SetActive (true);
			break;
		case 2:
			Data.Instance.scenesManager.ShowDoubleNavigationBack ();
			panel_email.SetActive (true);
			break;
		}
	}
	public void OnChangeCountry()
	{
	}
}
