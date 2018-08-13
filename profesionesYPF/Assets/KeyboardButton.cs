using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardButton : MonoBehaviour {

	public Text field;
	public KeyboardPanel panel;

	public void Init(KeyboardPanel panel, string text)
	{
		this.panel = panel;
		field.text = text;
	}
	public void Clicked()
	{
		panel.Clicked (field.text);
	}
}
