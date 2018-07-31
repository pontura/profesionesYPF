using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public states state;
	public enum states
	{
		TOUCH_UP
	}

	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			Events.OnInput (states.TOUCH_UP);
		}
	}
}