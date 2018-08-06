using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Share : MonoBehaviour {
	
	void Start () {
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.shareScreen);
	}

	void Update () {
		
	}
}
