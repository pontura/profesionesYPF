using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraggerManager : MonoBehaviour {

	public GameObject dragger;
	public GameObject asset;

	public bool dragging;
	Stickers stickers;

	void Start()
	{
		stickers = GetComponent<Stickers> ();
	}
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			dragging = true;
		} else if (Input.GetMouseButtonUp (0)) {
			StopDragging ();
		}
		if (dragging && asset != null) {
			Vector2 pos = Input.mousePosition;
			dragger.transform.position = pos;
		} 
	}
	public void OnItemSelected(GameObject newAsset)
	{
		asset = Instantiate (newAsset);
		Utils.RemoveAllChildsIn (dragger.transform);
		asset.transform.SetParent (dragger.transform);
		asset.transform.localScale = Vector3.one;
		asset.transform.localPosition = Vector3.zero;
	}
	public void StopDragging()
	{
		if (asset == null)
			return;
		stickers.AddSticker (asset, dragger.transform.position);
		dragging = false;
		asset = null;
		dragger.transform.position = new Vector2 (2000, -2000);
	}
}
