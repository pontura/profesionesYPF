using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupReset : MonoBehaviour {

	public GameObject panel;

	void Start () {
		panel.SetActive (false);
	}
	
	public void Init()
	{
		panel.SetActive (true);
	}
	public void OnRestart()
	{
		GetComponent<ScenesManager> ().Reset ();
		panel.SetActive (false);
	}
	public void OnContinue()
	{
		//GetComponent<CountDown> ().PauseCountdown ();
		GetComponent<CountDown> ().Restart ();
		panel.SetActive (false);
	}
}
