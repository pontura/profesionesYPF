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
}
