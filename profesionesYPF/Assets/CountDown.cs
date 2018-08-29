using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

	public GameObject panel;
	public Text field;
	int sec = 0;
	int initialSec;

	void Start () {
		panel.SetActive (false);
	}
	public void Init(int sec)
	{
		this.initialSec = sec;
		CancelInvoke ();
		this.sec = sec;
		Loop ();
	}
	public void PauseCountdown()
	{
		CancelInvoke ();
	}
	public void UnPauseCountdown()
	{
		Loop ();
	}
	public void Restart()
	{
		if (sec > 5)
			UnPauseCountdown ();
		else
			Init (initialSec);
	}
	void Loop()
	{
		string secText = sec.ToString ();
		if (secText.Length == 1)
			secText = "0" + secText;
		field.text = "00:" + secText;
		if (sec == 0) {
			Data.Instance.scenesManager.OpenResetPopup ();
			return;
		}
		Invoke ("Loop", 1);
		sec--;
	}
	public void SetStateBySceneID(int sceneNum)
	{
		if (sceneNum > 1)
			panel.SetActive (true);
		 else
			panel.SetActive (false);
	}
	public void Hide()
	{
		panel.SetActive (false);
		field.text = "";
		PauseCountdown ();
	}
}
