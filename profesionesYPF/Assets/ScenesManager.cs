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
	public bool isBack;

	public void LoadScene(string aLevelName)
	{
		
		SceneManager.LoadScene(aLevelName);

	}
	public void Next()
	{	
		if (isBack || UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name == "Stickers") {
			Events.BackClicked ();
			return;
		}
		JumpNext ();
	}
	public void JumpNext()
	{
		id++;
		print ("Load scene : "  + id);		
		SceneManager.LoadScene(id);
		Data.Instance.progressIcons.SetStateBySceneID(id);
		Data.Instance.countDown.SetStateBySceneID(id);
	}
	public void JumpBack()
	{
		id--;
		print ("Load scene : "  + id);		
		SceneManager.LoadScene(id);
		Data.Instance.progressIcons.SetStateBySceneID(id);
		Data.Instance.countDown.SetStateBySceneID(id);
	}
	public void OpenResetPopup()
	{
		GetComponent<PopupReset> ().Init ();
		GetComponent<CountDown> ().PauseCountdown ();
	}
	public void Reset()
	{
		Data.Instance.progressIcons.SetStatus (true);
		id=1;
		SceneManager.LoadScene(id);
		Data.Instance.Reset ();
		Data.Instance.progressIcons.Reset();
		Data.Instance.progressIcons.SetStateBySceneID(id);

		if (id == 1)
			Data.Instance.countDown.Hide ();
		else
			Data.Instance.countDown.SetStateBySceneID(id);
	}
	public void HomeClicked()
	{
		if (isBack)
			Events.BackClicked ();
		else
			OpenResetPopup ();
			//Data.Instance.scenesManager.Reset();
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
	public void HideAll()
	{
		simplePanel.SetActive (false);
		doublePanel.SetActive (false);
		Data.Instance.progressIcons.SetStatus (false);
	}

}
