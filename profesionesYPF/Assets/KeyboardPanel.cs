using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardPanel : MonoBehaviour {

	public string[] fields;
	public Transform container;
	public Text field;

	void Start()
	{
		int a = 0;
		foreach (KeyboardButton keyboardButton in container.GetComponentsInChildren<KeyboardButton>()) {
			keyboardButton.Init (this, fields [a]);
			a++;
		}
	}
	void OnEnable()
	{
		field.text = "";
	}
	public void Clicked(string text)
	{
		print (text);
		if (text == "<") {
			if (field.text.Length > 0)
				field.text = field.text.Remove (field.text.Length - 1, 1);
		} else if (text == "OK") {
			Events.OnKeyboardDone (field.text);
		}
		else
			field.text += text;
	}
}
