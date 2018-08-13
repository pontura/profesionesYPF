﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataTexts  {
	public string usar_instrumento;
	public string choose_category;
	public string intro_title1;
	public string intro_title2;
	public string choose_character;
	public string results_1;
	public string results_2;
	public string results_3;

	public string pregunta_1_1;
	public string pregunta_1_10;
	public string pregunta_1_11;
	public string pregunta_1_100;
	public string pregunta_1_101;
	public string pregunta_1_110;
	public string pregunta_1_111;

	public string pregunta_2_1;
	public string pregunta_2_10;
	public string pregunta_2_11;
	public string pregunta_2_100;
	public string pregunta_2_101;
	public string pregunta_2_110;
	public string pregunta_2_111;

	public string pregunta_3_1;
	public string pregunta_3_10;
	public string pregunta_3_11;
	public string pregunta_3_100;
	public string pregunta_3_101;
	public string pregunta_3_110;
	public string pregunta_3_111;

	public string pregunta_4_1;
	public string pregunta_4_10;
	public string pregunta_4_11;
	public string pregunta_4_100;
	public string pregunta_4_101;
	public string pregunta_4_110;
	public string pregunta_4_111;

	public List<Carrera> carreras;
}

[System.Serializable]
public class Carrera
{
	public int id;
	public string name;
	public string desc;
	public string duration;
	public List<MapSlots> mapSlots;
}
[System.Serializable]
public class MapSlots
{
	public int _x;
	public int _y;
	public string desc;
}
