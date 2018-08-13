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


	void Start()
	{
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.map);

		carreraNameField.text = Data.Instance.carrera.name;
		carreraNameDesc.text = Data.Instance.carrera.desc;
		carreraDuraction.text = Data.Instance.carrera.duration;

		AddSlots ();
	}
	public void Next()
	{
		Data.Instance.scenesManager.Next ();
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
		}
	}
	public void MapSlotClicked(int id)
	{
		mapDesc.text = Data.Instance.carrera.mapSlots [id].desc;
	}
}
