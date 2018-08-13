using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSlot : MonoBehaviour {

	int id;
	MapScreen mapScreen;

	public void Init(MapScreen mapScreen, int id)
	{
		this.mapScreen = mapScreen;
		this.id = id;
	}
	public void Clicked()
	{
		mapScreen.MapSlotClicked (id);
	}
}
