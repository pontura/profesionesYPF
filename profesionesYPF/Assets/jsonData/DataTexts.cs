using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataTexts  {

	public string intro_title1;
	public string intro_title2;
	public string choose_character;
	public string results_1;
	public string results_2;
	public string results_3;
	public string pregunta_1_1;
	public string pregunta_1_2;
	public string pregunta_1_3;
	public string pregunta_2_1;
	public string pregunta_2_2;
	public string pregunta_2_3;
	public string pregunta_3_1;
	public string pregunta_3_2;
	public string pregunta_3_3;
	public string pregunta_4_1;
	public string pregunta_4_2;
	public string pregunta_4_3;

	public List<Carrera> carreras;
}

[System.Serializable]
public class Carrera
{
	public int id;
	public string name;
	public string desc;
}
