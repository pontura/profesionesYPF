using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToHomePanel : MonoBehaviour {

	public GameObject panel;

	public void Clicked()
	{
		Data.Instance.scenesManager.Reset();
	}
}
