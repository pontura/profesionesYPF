using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScreen : MonoBehaviour {

	public Text carreraNameField;
	public Text carreraNameDesc;
	public Text carreraDuraction;
	public Text mapDesc;
	public Transform map_container;
	public MapSlot mapSlot;
	public List<MapSlot> slots;
	public Image summaryImage;

	public GameObject help1;
	public GameObject help2;

	void Start()
	{	

		Data.Instance.scenesManager.ShowDoubleNavigation ();
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.map);

		carreraNameField.text = Data.Instance.carrera.name;
		carreraNameDesc.text = Data.Instance.carrera.desc;
		carreraDuraction.text = Data.Instance.carrera.duration;

		Sprite s = Resources.Load("summary/" +  Data.Instance.carrera.id, typeof(Sprite)) as Sprite;
		summaryImage.sprite = s;

		AddSlots ();

		MapSlotClicked (Random.Range(0,slots.Count));

		help1.SetActive (true);
		help2.SetActive (false);
	}
	void AddSlots()
	{
		int id = 0;
		foreach (MapSlots mapSlots in Data.Instance.carrera.mapSlots) {
			MapSlot newMapSlot = Instantiate (mapSlot);
			newMapSlot.transform.SetParent (map_container);
			newMapSlot.transform.localPosition = new Vector2 (mapSlots._x, mapSlots._y);
			newMapSlot.transform.localScale = Vector2.one;
			newMapSlot.Init(this, id);
			id++;
			slots.Add (newMapSlot);
		}
	}
	public void MapSlotClicked(int id)
	{
		help1.SetActive (false);
		help2.SetActive (true);

		Color c;
		foreach (MapSlot mapSlot in slots) {
			c = mapSlot.GetComponentInChildren<Image> ().color;
			c.a = 0.5f;
			mapSlot.GetComponentInChildren<Image> ().color = c;
		}

		c = slots[id].GetComponentInChildren<Image> ().color;
		c.a = 1;
		slots[id].GetComponentInChildren<Image> ().color = c;

		mapDesc.text = Data.Instance.carrera.mapSlots [id].desc;
	}
}
