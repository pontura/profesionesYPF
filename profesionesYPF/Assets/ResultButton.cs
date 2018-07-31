using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButton : MonoBehaviour {

	int id;
	Results results;
	public void Init(Results results, int id)
	{
		this.results = results;
		this.id = id;
	}
	public void OnSelected()
	{
		results.OnSelected (id);
	}
}
