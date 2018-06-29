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

		if (handObjectChecker.dposHandRight.y == 0 || handObjectChecker.dposHandLeft.y == 0)
			return;
		
		neck = Mathf.Lerp (neck, handObjectChecker.dposNeck.y, 0.2f);
		rightHand = Mathf.Lerp (rightHand, handObjectChecker.dposHandRight.y, 0.2f);
		leftHand = Mathf.Lerp (leftHand, handObjectChecker.dposHandLeft.y, 0.2f);

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
