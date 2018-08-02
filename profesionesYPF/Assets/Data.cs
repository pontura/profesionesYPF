﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Data : MonoBehaviour
{
    const string PREFAB_PATH = "Data";    
    static Data mInstance = null;
	public HeadCharacter headCharacter;
	public ScenesManager scenesManager;
	public ProgressIcons progressIcons;
	public characterTypes characterType;
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
		scenesManager.Next ();
    }
	public void Reset()
	{
		questionID = 0;
	}
}
