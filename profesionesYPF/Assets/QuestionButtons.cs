using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionButtons : MonoBehaviour {

	public QuestionButton[] buttons;
	public int questionID = 0;
	Questions questions; 

	public void Init(int questionID) {
		foreach (QuestionButton qb in buttons) {
			qb.Init (questionID);
		}
	}
}
