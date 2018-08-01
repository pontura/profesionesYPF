using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressIcon : MonoBehaviour {

	public Image image;
	public Sprite iconOn;
	public Sprite iconOff;

	public void SetState(bool isOn)
	{
		if (isOn)
			image.sprite = iconOn;
		else
			image.sprite = iconOff;
	}
}
