using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour {

	public Text title;
	public RawImage rawimage;
	public Camera cam_outline;
	public Camera cam;
	public Image image;
	public Sprite image_parate;
	public Sprite image_3;
	public Sprite image_2;
	public Sprite image_1;
	public SetFaceTexture setFaceTracking;

	public states state;
	//public GameObject freezeRotationGO;
	public Text field;
	public GameObject help;

	public enum states
	{
		WAITING,
		COUNT_DOWN
	}
	int countDown;

	void Start()
	{
		field.text = "";
		help.SetActive (true);
		Data.Instance.scenesManager.ShowSimpleNavigation ();
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.photo+1000);

		title.text = Data.Instance.texts.photo_instructions;
		rawimage.enabled = false;
		OnUserStatus (false);
		//field.text = Data.Instance.texts.usar_instrumento;
		//Events.OnUserStatus += OnUserStatus;

		Invoke ("rawimageOn", 1);
	}
	void rawimageOn()
	{
		rawimage.enabled = true;
	}
	void Update()
	{
		if (setFaceTracking.isValid && state == states.WAITING) {
			OnUserStatus (true);
			Loop ();
		} else if (!setFaceTracking.isValid && state == states.COUNT_DOWN) {
			OnUserStatus (false);
		}
	}
//	void LateUpdate()
//	{
//		freezeRotationGO.transform.localEulerAngles = Vector3.zero;
//	}
	void OnUserStatus(bool isOn)
	{
		if (isOn) {
			//field.text = "En zona!";
			help.SetActive (false);
			state = states.COUNT_DOWN;
		}
		else {
			help.SetActive (true);
			//field.text = "No estas en zona...";
			CancelInvoke ();
			Reset ();

		}
	}
	void Reset()
	{
		image.sprite = image_parate;
		state = states.WAITING;
		countDown = 0;
		CancelInvoke ();
	}
	void Loop()
	{
		if (!setFaceTracking.isValid) {
			OnUserStatus (false);
			return;
		} else if (countDown > 3) {
			Done ();
			return;
		}
		countDown++;
		switch (countDown) {
		case 1:
			image.sprite = image_3;
			break;
		case 2:
			image.sprite = image_2;
			break;
		case 3:
			image.sprite = image_1;
			break;
		}
		Invoke ("Loop", 1);

	}
	bool done;
	public void Done()
	{
		if (done)
			return;
		
//		Data.Instance.rt = cam.targetTexture;
//		Data.Instance.texture2d = new Texture2D (cam.targetTexture.width, cam.targetTexture.height);
//		Data.Instance.texture2d.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
//		Data.Instance.texture2d.Apply();

		cam.enabled = false;
		cam.targetTexture = null;
		cam_outline.targetTexture = null;
		done = true;
		//Data.Instance.screenshotManager.Init (false);
		Invoke ("Next",0.5f);
		Next ();
	}
	void Next()
	{
		Data.Instance.scenesManager.Next ();
		//UnityEngine.SceneManagement.SceneManager.LoadScene ("Stickers");
	}
	void OnDestroy()
	{
		Destroy (GameObject.Find ("KinectController"));
	}
//	public void SetPhoto()
//	{
//		facetrackingManager.pauseModelMeshUpdates = true;
//		facetrackingManager.getFaceModelData = false;
//		headCharacter.Init(faceModelMesh);
//		Invoke ("Delayed", 1);
//		characterInScene.Init (headCharacter);
//	}
//	public void Reset()
//	{
//		Destroy (facetrackingManager.gameObject);
//
//	}
}
