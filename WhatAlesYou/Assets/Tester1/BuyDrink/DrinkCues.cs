using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cradle;
using UnityEngine.UI;

public class DrinkCues : MonoBehaviour {

	public Story story;
	public GameObject twinePlayer;
	public GameObject background;

	public bool isPaused = false;
	public bool waitingDrink = false;

	// Use this for initialization
	void Start () {
		
	}

	[StoryCue("Order Up!", "Exit")]
	void makeDrink()
	{
		isPaused = true;

		//pauses the dialogue, and removes UI elements to allow for drink mixing gameplay
		story.Pause();
		twinePlayer.GetComponent<TwineTextPlayer>().AutoDisplay = false;
		twinePlayer.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background.GetComponent<RectTransform>().localScale.y, background.GetComponent<RectTransform>().localScale.z);
		
		waitingDrink = true;
	}

	void giveDrink()
	{
		isPaused = false;

		//resumes game when player gives customer the drink
		twinePlayer.GetComponent<TwineTextPlayer>().AutoDisplay = true;
		twinePlayer.GetComponent<RectTransform>().localScale = new Vector3(0.8f, background.GetComponent<RectTransform>().localScale.y, background.GetComponent<RectTransform>().localScale.z);
		twinePlayer.GetComponent<TwineTextPlayer>().Story.Resume();

		waitingDrink = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
