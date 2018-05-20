using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cradle;

public class friendInteract : MonoBehaviour {
	public Story story1;
	public Story story2;
	public GameObject twinePlayer1;
	public GameObject twinePlayer2;
	public GameObject background1;
	public GameObject background2;

	public StoryOutput cout;

	public bool customerInteract = false; //if we initiated contact
	public bool waitingDrink = false; //if they ordered drink and wait for player
	public bool isPaused = false;

	public bool passageOneDone = false;
	public bool passageTwoRun = false;

	// Use this for initialization
	void Start () {

	}

	//when u click on friend, this object will pop up the dialogue.
	//if friend is talking, the dialogue box will pop up once and 
	//twine will take over.
	void OnMouseDown()
	{
		//set bool to true to allow only one click to start dialogue.
		if (customerInteract == false)
		{
			customerInteract = true;

			//code block that pops up dialogue and runs twine dialogue.
			twinePlayer1.GetComponent<TwineTextPlayer>().AutoDisplay = true;
			twinePlayer1.GetComponent<TwineTextPlayer>().StartStory = true;
			background1.GetComponent<RectTransform>().localScale = new Vector3(0.8f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);

			if (twinePlayer1.GetComponent<TwineTextPlayer>().AutoDisplay)
			{
				story1.Begin();
			}
		}

		if (waitingDrink)
		{
			isPaused = false;
			waitingDrink = false;
		}
		
		if (passageTwoRun)
		{
			gaveDrink();
		}
	}

	void gaveDrink()
	{
		//start next dialogue
		twinePlayer2.GetComponent<TwineTextPlayer>().AutoDisplay = true;
       	twinePlayer2.GetComponent<TwineTextPlayer>().StartStory = true;
       	background2.GetComponent<RectTransform>().localScale = new Vector3(0.8f, background2.GetComponent<RectTransform>().localScale.y, background2.GetComponent<RectTransform>().localScale.z);
		story2.Begin();
	}


    // Update is called once per frame 
    void Update () {
		if (story1.CurrentPassage.Name == "Order Up" && Input.GetKeyDown(KeyCode.Mouse0))
		{
			passageOneDone = true;
		}

		if (passageOneDone)
		{
			//transitions to the next block of dialogue in game

			//twinePlayer1.GetComponent<TwineTextPlayer>().AutoDisplay = false;
       		//twinePlayer1.GetComponent<TwineTextPlayer>().StartStory = false;
       		//background1.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);
			passageOneDone = false;
			twinePlayer1.SetActive(false);

			passageTwoRun = true;
		}
	}
}
