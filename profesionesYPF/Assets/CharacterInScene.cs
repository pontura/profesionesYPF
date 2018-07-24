using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInScene : MonoBehaviour {

	public Transform headContainer;

	public void Init (HeadCharacter head) {
		head.transform.SetParent (headContainer);
		transform.localPosition = new Vector3 (0, 0, 0);
		head.transform.localScale = Vector3.one;
		head.transform.localPosition = Vector3.zero;
		head.transform.localEulerAngles = Vector3.zero;
	}
}
