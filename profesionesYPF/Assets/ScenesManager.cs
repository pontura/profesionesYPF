using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour {

	public int id;

	public void LoadScene(string aLevelName)
	{
		SceneManager.LoadScene(aLevelName);
	}
	public void Next()
	{		
		id++;
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

}
