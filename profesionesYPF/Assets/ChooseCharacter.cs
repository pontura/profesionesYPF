using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : SceneBase {

	void Start () {
		
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
