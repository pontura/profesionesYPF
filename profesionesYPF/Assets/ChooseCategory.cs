using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseCategory : MonoBehaviour {

	public Text title;
	void Start () {
		title.text = Data.Instance.texts.choose_category;
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.chooseCategory);
	}
	public void Choose(int id)
	{
		switch( id)
		{
		case 1:
			Data.Instance.categoryType = Data.categoriesTypes.TIERRA;
			Data.Instance.results.x = 1;
			break;
		case 2:
			Data.Instance.categoryType = Data.categoriesTypes.FISICA ;
			Data.Instance.results.x = 2;
			break;
		case 3:
			Data.Instance.categoryType = Data.categoriesTypes.PETROLEO ;
			Data.Instance.results.x = 3;
			break;
		case 4:
			Data.Instance.categoryType = Data.categoriesTypes.ELECTRICA ;
			Data.Instance.results.x = 4;
			break;
		}
		Data.Instance.scenesManager.Next ();
	}
}
