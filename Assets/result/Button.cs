﻿using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ResetButton()
	{
		Application.LoadLevel("Game");
	}

	public void TitleButton()
	{
		Application.LoadLevel("Title");
	}
}
