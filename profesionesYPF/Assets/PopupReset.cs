using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupReset : MonoBehaviour {

	public GameObject panel;
	bool isOn;

	void Start () {
		panel.SetActive (false);
	}
	
	public void Init()
	{ 
		isOn = true;
		panel.SetActive (true);
		Invoke ("timeout", 15);
	}
	void timeout()
	{
		if (!isOn)
			return;
		OnRestart ();
	}
	public void OnRestart()
	{
		isOn = false;
		GetComponent<ScenesManager> ().Reset ();
		panel.SetActive (false);
	}
	public void OnContinue()
	{
		isOn = false;
		//GetComponent<CountDown> ().PauseCountdown ();
		GetComponent<CountDown> ().Restart ();
		panel.SetActive (false);
	}
}
