using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVote : MonoBehaviour {

	public Text field;
	public Slider slider;
	float lastValue;

	void Update () {
		float value = slider.value;
		if (lastValue == value)
			return;
		lastValue = value;

		Data.Instance.vote = (int)Mathf.Round (value)+1;
		field.text = Data.Instance.dataConfig.settings.vote [Data.Instance.vote-1];
	}
}
