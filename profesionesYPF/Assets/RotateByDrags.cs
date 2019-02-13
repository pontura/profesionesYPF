using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateByDrags : MonoBehaviour {

	//public Text field;
	public Image drag1;
	public Image drag2;
	float initAngle;
	bool calculateAngle;
	public GameObject toRotate;
	public DraggerManager dragger;

	void Update () {
		
		if (dragger.restrictions != Vector2.zero)
			return;
		print (Input.touchCount);
		if (Input.touchCount > 1) {
			drag1.transform.localPosition = Input.touches [0].position;
			drag2.transform.localPosition = Input.touches [1].position;
			if (!calculateAngle) {
				//float angle = Mathf.Atan2(p2.y-p1.y, p2.x-p1.x)*180 / Mathf.PI;
				float angle = Mathf.Atan2(drag2.transform.localPosition.y-drag1.transform.localPosition.y, drag2.transform.localPosition.x-drag1.transform.localPosition.x)*180 / Mathf.PI;
				initAngle = angle - toRotate.transform.localEulerAngles.z;
				calculateAngle = true;

				toRotate.transform.localEulerAngles = new Vector3(0,Random.Range(0,300),0);
			}
			float newAngle = (Mathf.Atan2(drag2.transform.localPosition.y-drag1.transform.localPosition.y, drag2.transform.localPosition.x-drag1.transform.localPosition.x)*180 / Mathf.PI) - initAngle;
			//field.text = newAngle.ToString();
			toRotate.transform.localEulerAngles = new Vector3(0,0,newAngle);
		} else {
			calculateAngle = false;
		}

	}
}
