using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : SceneBase {

	public GameObject[] slides;
	int id;
	public Text title1;
	public Text title2;

	void Start () {
		Events.OnInput += OnInput;

		title1.text = Data.Instance.texts.intro_title1;
		title2.text = Data.Instance.texts.intro_title2;
		Loop ();
	}
	void OnDestroy () {
		Events.OnInput -= OnInput;
	}
	public void OnInput(InputManager.states state)
	{
		if (state == InputManager.states.TOUCH_UP)
			Data.Instance.scenesManager.Next ();
	}
	void Loop()
	{
		if (id == slides.Length)
			id = 0;
		if (id == 0)
			ClearAll ();
		slides [id].SetActive (true);
		id++;
		Invoke ("Loop", 2);
	}
	void ClearAll()
	{
		foreach (GameObject go in slides)
			go.SetActive (false);
	}
}
