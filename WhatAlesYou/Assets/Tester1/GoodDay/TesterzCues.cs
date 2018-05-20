using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cradle;
using UnityEngine.UI;

public class TesterzCues : MonoBehaviour {

	public Story story;
	
	// Use this for initialization
	void Start () {
		
	}
	
	[StoryCue("They Good", "Enter")]
	void enterGood()
	{
		//story.GetComponent<Image>().color = Color.yellow;
	}

	[StoryCue("They Bad", "Enter")]
	void enterBad()
	{
		//story.GetComponent<Image>().color = Color.blue;
	}

	[StoryCue("Ending", "Enter")]
	void enterEnd()
	{
		//story.GetComponent<Image>().color = Color.black;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
