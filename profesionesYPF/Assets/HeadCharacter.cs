using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCharacter : MonoBehaviour {

	public Transform headContainer;

	void Start () {
		
	}
	public void Init(GameObject headCharacter) {
		headCharacter.transform.SetParent (headContainer);
	}
}
