using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCharacter : SceneBase {

	public Text title;

	void Start () {
		title.text = Data.Instance.texts.choose_character;
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.chooseCharacter);
	}
	public void Choose(int id)
	{
		switch( id)
		{
		case 1:
			Data.Instance.characterType = Data.characterTypes.HE;
			break;
		case 2:
			Data.Instance.characterType = Data.characterTypes.SHE;
			break;
		}
		Data.Instance.scenesManager.Next ();
	}
}
