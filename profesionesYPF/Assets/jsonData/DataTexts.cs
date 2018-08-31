using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataTexts  {
	
	public string choose_category;
	public string intro_title1;
	public string intro_title2;
	public string choose_character;
	public string results_1;
	public string results_2;
//	public string map_instructions;
	public string photo_instructions;
	public string share_instructions;
	public string lastScreen_text1;
	public string lastScreen_text2;
	public string photo_ready_title;
	public string stickers_title;
	public string photo_ready_subtitle;
	public string enjoy;
	public string accept;

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

	public TriviaResults r_1_0_0_0;
	public TriviaResults r_1_0_0_1;
	public TriviaResults r_1_0_1_1;
	public TriviaResults r_1_1_1_1;
	public TriviaResults r_1_1_1_0;
	public TriviaResults r_1_1_0_0;
	public TriviaResults r_1_0_1_0;
	public TriviaResults r_1_1_0_1;

	public TriviaResults r_2_0_0_0;
	public TriviaResults r_2_0_0_1;
	public TriviaResults r_2_0_1_1;
	public TriviaResults r_2_1_1_1;
	public TriviaResults r_2_1_1_0;
	public TriviaResults r_2_1_0_0;
	public TriviaResults r_2_0_1_0;
	public TriviaResults r_2_1_0_1;

	public TriviaResults r_3_0_0_0;
	public TriviaResults r_3_0_0_1;
	public TriviaResults r_3_0_1_1;
	public TriviaResults r_3_1_1_1;
	public TriviaResults r_3_1_1_0;
	public TriviaResults r_3_1_0_0;
	public TriviaResults r_3_0_1_0;
	public TriviaResults r_3_1_0_1;

	public TriviaResults r_4_0_0_0;
	public TriviaResults r_4_0_0_1;
	public TriviaResults r_4_0_1_1;
	public TriviaResults r_4_1_1_1;
	public TriviaResults r_4_1_1_0;
	public TriviaResults r_4_1_0_0;
	public TriviaResults r_4_0_1_0;
	public TriviaResults r_4_1_0_1;

	public string[] iconos_tags;
	public string[] iconos_generics;
	public string[] iconos_cat_1;
	public string[] iconos_cat_2;
	public string[] iconos_cat_3;
	public string[] iconos_cat_4;

	public List<Carrera> carreras;
}

[System.Serializable]
public class Carrera
{
	public int id;
	public int categoria;
	public string name;
	public string desc;
	public string duration;
	public List<MapSlots> mapSlots;
	public List<string> stickers_icons;
}
[System.Serializable]
public class MapSlots
{
	public int _x;
	public int _y;
	public string desc;
}
[System.Serializable]
public class TriviaResults
{
	public int resaltada;
	public int[] mostrar;
}