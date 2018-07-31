using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

	public GameObject[] slides;
	int id;

	void Start () {
		Events.OnInput += OnInput;
	}
	void OnDestroy () {
		Events.OnInput -= OnInput;
	}
	public void OnInput(InputManager.states state)
	{
		if(state == InputManager.states.TOUCH_UP)
			Data.Instance.LoadLevel ("02_Preguntas");
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
