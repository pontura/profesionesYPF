using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressIcons : MonoBehaviour {

	public List<ProgressIcon> icons;
	public ProgressIcon progressIcon;
	public int total;
	public Transform container;
	public GameObject panel;
	public int id;

	void Start()
	{
		for (int a = 0; a < total; a++) {
			ProgressIcon pi = Instantiate (progressIcon);
			pi.transform.SetParent (container);
			pi.SetState (false);
			icons.Add (pi);
		}
		SetState (false);
	}
	public void Reset()
	{
		SetState (false);
		id = 0;
	}
	public void SetStateBySceneID(int sceneNum)
	{
		if (sceneNum > 1) {
			SetState (true);
			ActivateIcon (id);
			id++;
		}
		else
			SetState (false);		

	}
	public void SetState(bool isOn)
	{
		panel.SetActive (isOn);
	}
	public void ActivateIcon(int id)
	{
		ResetIcons ();
		icons[id].SetState (true);
	}
	void ResetIcons()
	{
		foreach (ProgressIcon pi in icons)
			pi.SetState (false);
	}
}