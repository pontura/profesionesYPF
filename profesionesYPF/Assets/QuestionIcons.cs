using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionIcons : MonoBehaviour {

	public Image[] icons;
	public Sprite iconOn;

	public void Init(int questionID) {
		icons [questionID].sprite = iconOn;
	}
}
