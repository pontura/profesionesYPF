using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCategory : MonoBehaviour {

	void Start () {
		
	}
	public void Choose(int id)
	{
		switch( id)
		{
		case 1:
			Data.Instance.categoryType = Data.categoriesTypes.TIERRA ;
			break;
		case 2:
			Data.Instance.categoryType = Data.categoriesTypes.FISICA ;
			break;
		case 3:
			Data.Instance.categoryType = Data.categoriesTypes.PETROLEO ;
			break;
		case 4:
			Data.Instance.categoryType = Data.categoriesTypes.ELECTRICA ;
			break;
		}
		Data.Instance.scenesManager.Next ();
	}
}
