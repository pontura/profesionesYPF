using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour {

	public int id;
	public GameObject simplePanel;
	public GameObject doublePanel;
	public Image iconNextBack; 
	bool isBack;

	public void LoadScene(string aLevelName)
	{
		SceneManager.LoadScene(aLevelName);
	}
	public void Next()
	{		
		id++;
		print ("Load scene : "  + id);
		SceneManager.LoadScene(id);
		Data.Instance.progressIcons.SetStateBySceneID(id);
		Data.Instance.countDown.SetStateBySceneID(id);
	}
	public void Reset()
	{
		id=1;
		SceneManager.LoadScene(id);
		Data.Instance.Reset ();
		Data.Instance.progressIcons.Reset();
		Data.Instance.progressIcons.SetStateBySceneID(id);
		Data.Instance.countDown.SetStateBySceneID(id);
	}
	public void HomeClicked()
	{
		if (isBack)
			Events.BackClicked ();
		else
			Data.Instance.scenesManager.Reset();
	}
	public void ShowSimpleNavigation()
	{
		simplePanel.SetActive (true);
		doublePanel.SetActive (false);
	}
	public void ShowDoubleNavigation()
	{
		isBack = false;
		simplePanel.SetActive (false);
		doublePanel.SetActive (true);
		iconNextBack.transform.localScale = new Vector2 (1, 1);
	}
	public void ShowDoubleNavigationBack()
	{
		isBack = true;
		simplePanel.SetActive (false);
		doublePanel.SetActive (true);
		iconNextBack.transform.localScale = new Vector2 (-1, 1);
	}

}
