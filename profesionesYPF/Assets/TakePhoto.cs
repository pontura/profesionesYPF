using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour {

	public Image image;
	public Sprite image_parate;
	public Sprite image_preparate;
	public Sprite image_3;
	public Sprite image_2;
	public Sprite image_1;

	public states state;
	public GameObject freezeRotationGO;

	public enum states
	{
		WAITING,
		COUNT_DOWN
	}
	int countDown;

	void Start()
	{
		Events.OnUserStatus += OnUserStatus;
	}
	void LateUpdate()
	{
		freezeRotationGO.transform.localEulerAngles = Vector3.zero;
	}
	void OnUserStatus(bool isOn)
	{
		print ("OnUserStatus " + isOn + " state " + state);
		if (state == states.WAITING && isOn) {
			state = states.COUNT_DOWN;
			Loop ();
		} else if (state == states.COUNT_DOWN && !isOn) {			
			Reset ();
		}
	}
	void Reset()
	{
		state = states.WAITING;
		countDown = 0;
		CancelInvoke ();
	}
	void Loop()
	{
		if (countDown > 4) {
			return;
		}
		switch (countDown) {
		case 0:
			image.sprite = image_parate;
			break;
		case 1:
			image.sprite = image_preparate;
			break;
		case 2:
			image.sprite = image_3;
			break;
		case 3:
			image.sprite = image_2;
			break;
		case 4:
			image.sprite = image_1;
			break;
		}
		Invoke ("Loop", 1);
		countDown++;
	}
	bool done;
	public void Done()
	{
		if (done)
			return;
		done = true;
		StartCoroutine (TakeSnapshot (1080, 1080));
	}
	WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
	public IEnumerator TakeSnapshot(int w, int h)
	{
		yield return frameEnd;

		Texture2D texture = new Texture2D(w,h, TextureFormat.RGB24, true);
		texture.ReadPixels(new Rect(0, 1920-1080, w, h), 0, 0);
		texture.LoadRawTextureData(texture.GetRawTextureData());
		texture.Apply();
		Data.Instance.texture2d = texture;
		Next ();
	}
	void Next()
	{
		Data.Instance.scenesManager.Next ();
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
