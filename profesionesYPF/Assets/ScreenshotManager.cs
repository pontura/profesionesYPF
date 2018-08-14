using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScreenshotManager : MonoBehaviour {

	public int _w = 1080;
	public int _h = 1080;
	float offsetY = 280;
	float offset_Y;
	bool saveItToDisk;

	void Start()
	{
		offset_Y = 1920 - 1080;
		offset_Y -= offsetY;
	}
	public void Init(bool saveItToDisk)
	{
		Data.Instance.countDown.Hide ();
		this.saveItToDisk = saveItToDisk;
		StartCoroutine (TakeSnapshot (_w, _h));
	}
	WaitForEndOfFrame frameEnd = new WaitForEndOfFrame();
	public IEnumerator TakeSnapshot(int w, int h)
	{
		yield return frameEnd;

		Texture2D texture = new Texture2D(w,h, TextureFormat.RGB24, true);
		texture.ReadPixels(new Rect(0, offset_Y, w, h), 0, 0);
		texture.LoadRawTextureData(texture.GetRawTextureData());
		texture.Apply();
		Data.Instance.texture2d = texture;

		if (saveItToDisk)
			SaveIt ();
	}
	void SaveIt()
	{
		StartCoroutine (UploadPNG());
	}
	IEnumerator UploadPNG()
	{
		yield return new WaitForEndOfFrame();

		Texture2D tex = Data.Instance.texture2d;

		tex.ReadPixels(new Rect(0, offset_Y, _w, _h), 0, 0);
		tex.Apply();

		Data.Instance.texture2d = tex;

		byte[] bytes = tex.EncodeToPNG();
		//Object.Destroy(tex);

		 File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

	}

}
