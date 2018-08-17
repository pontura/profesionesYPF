using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataConfig : MonoBehaviour {
	
	public DataSettings settings;

	void Start()
	{
		LoadTexts ();
		LoadSettings ();
	}
	void LoadTexts()
	{
		string Path = Application.streamingAssetsPath + "/texts.json";
		string jsonString = File.ReadAllText (Path);
		Data.Instance.texts = JsonUtility.FromJson<DataTexts> (jsonString);
	}
	void LoadSettings()
	{
		string Path = Application.streamingAssetsPath + "/settings.json";
		string jsonString = File.ReadAllText (Path);
		settings = JsonUtility.FromJson<DataSettings> (jsonString);
	}

	[System.Serializable]
	public class DataSettings
	{
		public Duration timer;
		public List<CountryData> countries;
	}
	[System.Serializable]
	public class Duration
	{
		public int chooseCharacter;
		public int chooseCategory;
		public int results;
		public int map;
		public int trivia;
		public int video;
		public int photo;
		public int stickers;
		public int photoReady;
		public int shareScreen;
		public int lastScreen;
	}
	[System.Serializable]
	public class CountryData
	{
		public string name;
		public int number;
	}

}
