using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataConfig : MonoBehaviour {

	string Path;
	string jsonString;

	void Start()
	{
		Path = Application.streamingAssetsPath + "/texts.json";
		jsonString = File.ReadAllText (Path);
		Data.Instance.texts = JsonUtility.FromJson<DataTexts> (jsonString);
	}

}
