using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapScreen : MonoBehaviour {

	public Text carreraNameField;
	public Text carreraNameDesc;
	public Text carreraDuraction;
	public Text mapDesc;
	public Text mapInstructions;
	public Transform map_container;
	public MapSlot mapSlot;
	public List<MapSlot> slots;

	void Start()
	{
		Data.Instance.scenesManager.ShowDoubleNavigation ();
		Data.Instance.countDown.Init (Data.Instance.dataConfig.settings.timer.map);

		carreraNameField.text = Data.Instance.carrera.name;
		carreraNameDesc.text = Data.Instance.carrera.desc;
		carreraDuraction.text = Data.Instance.carrera.duration;
		mapInstructions.text = Data.Instance.texts.map_instructions;

		AddSlots ();

		MapSlotClicked (Random.Range(0,slots.Count));
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
