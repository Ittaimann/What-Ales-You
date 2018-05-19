using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cradle;

public class TesterzCues : MonoBehaviour {

	public Story story;
	
	// Use this for initialization
	void Start () {
		
	}
	
	[StoryCue("They Good", "Enter")]
	void enterGood()
	{
		Camera.main.backgroundColor = Color.yellow;
	}

	[StoryCue("They Bad", "Enter")]
	void enterBad()
	{
		Camera.main.backgroundColor = Color.blue;
	}

	[StoryCue("Ending", "Enter")]
	void enterEnd()
	{
		Camera.main.backgroundColor = Color.black;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
