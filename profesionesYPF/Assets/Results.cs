using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Results : MonoBehaviour {

	public ResultButton button;
	public Transform container;

	void Start()
	{
		for (int a = 0; a < 3; a++) {
			ResultButton b = Instantiate (button);
			b.transform.SetParent (container);
			b.Init (this, a);
		}
	}
	public void OnSelected(int id)
	{
		Data.Instance.LoadLevel ("03_Map");
	}
}
