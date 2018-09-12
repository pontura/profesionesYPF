using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Data : MonoBehaviour
{
    const string PREFAB_PATH = "Data";    
    static Data mInstance = null;
	public HeadCharacter headCharacter;
	[HideInInspector]
	public ScenesManager scenesManager;
	[HideInInspector]
	public ProgressIcons progressIcons;
	public characterTypes characterType;
	[HideInInspector]
	public DataConfig dataConfig;
	//[HideInInspector]
	public DataTexts texts;
	public Vector4 results;
	public Carrera carrera;
	public Texture2D texture2d;
	public CountDown countDown;
	public ScreenshotManager screenshotManager;
	public RenderTexture rt;
	public string imageName;

	public enum characterTypes
	{
		HE,
		SHE
	}
	public categoriesTypes categoryType;
	public enum categoriesTypes
	{
		TIERRA,
		FISICA,
		PETROLEO,
		ELECTRICA
	}
	public int questionID;
    public static Data Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Data>();

                if (mInstance == null)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
                    mInstance = go.GetComponent<Data>();
                }
            }
            return mInstance;
        }
    }
    public string currentLevel;
   
    void Awake()
    {
		//GetImageName ();
		QualitySettings.vSyncCount = 1;
		//Cursor.visible = false;

        if (!mInstance)
            mInstance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
       
        DontDestroyOnLoad(this.gameObject);

		scenesManager = GetComponent<ScenesManager> ();
		dataConfig = GetComponent<DataConfig> ();
    }

	public void Reset()
	{
		questionID = 0;
	}
	public void SendData()
	{
		
	}
	public string GetImageName()
	{
		imageName = 
			System.DateTime.Now.Year.ToString () + 
			System.DateTime.Now.Month.ToString () + 
			System.DateTime.Now.Day.ToString () + 
			System.DateTime.Now.Hour.ToString () + 
			System.DateTime.Now.Minute.ToString () + 
			System.DateTime.Now.Second.ToString () + 
			System.DateTime.Now.Millisecond.ToString () + ".png";
		
		return imageName;
	}
}
