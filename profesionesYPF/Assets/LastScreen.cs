using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastScreen : MonoBehaviour {

	public Text lastScreen_text1;
	public Text lastScreen_text2;

	void Start () {

		Data.Instance.scenesManager.HideAll ();
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.lastScreen);

		lastScreen_text1.text = Data.Instance.texts.lastScreen_text1;
		lastScreen_text2.text = Data.Instance.texts.lastScreen_text2;

		Invoke ("Reset", 4);
	}

	void Reset () {
		Data.Instance.scenesManager.Reset ();
	}
}
