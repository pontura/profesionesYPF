using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public states state;
	public enum states
	{
		NONE,
		LEFT,
		RIGHT
	}
	float neck;
	float rightHand;
	float leftHand;

	HandObjectChecker handObjectChecker;

	void Start () {
		handObjectChecker = GetComponent<HandObjectChecker> ();
	}

	void Update () {


		if (rightHand > neck && leftHand > neck)
			ChangeState( states.NONE );
		else if (leftHand < rightHand)
			ChangeState( states.LEFT );
		else
			ChangeState( states.RIGHT);
	}
	states lastState;
	public void ChangeState(states newState)
	{
		if (newState == lastState)
			return;
		lastState = newState;
		print ("CAMBIO" + newState);
		////////-> Evento de cuando cambia:
		/// 
	}
}
