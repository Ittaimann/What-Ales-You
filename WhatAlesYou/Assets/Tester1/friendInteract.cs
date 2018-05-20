using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cradle;

public class friendInteract : MonoBehaviour {
	public GameObject steve, gus;
	public GameObject mixer;
	//there are going to be n story objects to transition in twine
	public Story story1, story2, story3, story4, 
	story5, story6, story7, story8, story9;
	//there are n twineplayers for the story objects
	public GameObject twinePlayer1, twinePlayer2, twinePlayer3,
	twinePlayer4, twinePlayer5, twinePlayer6, twinePlayer7,
	twinePlayer8, twinePlayer9;

	//there are n backgrounds for the dialogue boxes
	public GameObject background1, background2, background3, background4,
	background5, background6, background7, background8, background9;

	public bool customerInteract = false; //if we initiated contact
	public bool waitingDrink = false; //if they ordered drink and wait for player
	public bool isPaused = false;

	int drinkCount = 0;

	private bool passageOneDone = false; //if story 1 is done
	//will need to add more bools here

	// Use this for initialization
	void Start () {
		background1.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);
		background2.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);
		background3.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);
		//background4.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);
		//background5.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);
		//background6.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);
		//background7.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);
		//background8.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);
		//background9.GetComponent<RectTransform>().localScale = new Vector3(0.0f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);

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
			background1.GetComponent<RectTransform>().localScale = new Vector3(0.4f, background1.GetComponent<RectTransform>().localScale.y, background1.GetComponent<RectTransform>().localScale.z);

			//start the beginning of the story when click player
			if (twinePlayer1.GetComponent<TwineTextPlayer>().AutoDisplay)
			{
				story1.Begin();
			}
		}

		//if the customer is waiting on on their drink.
		//for the purpose of this test, we trigger new dialogue by clicking.
		//Ideally these flags would trigger when handing the customer their drink.
		if (waitingDrink)
		{
			isPaused = false;
			waitingDrink = false;
		}
		
		//if (passageTwoRun && background2.GetComponent<RectTransform>().localScale.x != 0.4f)
		//{
		//	gaveDrink();
		//}
	}

	//triggered when we hand the customer their drink.
	//we will start the next block of dialogue.
	public void gaveDrink(bool hasPoison)
	{
		if (drinkCount == 0)
		{
			//dialogue gave first drink to Stephan
			twinePlayer3.GetComponent<TwineTextPlayer>().AutoDisplay = true;
       		twinePlayer3.GetComponent<TwineTextPlayer>().StartStory = true;
       		background3.GetComponent<RectTransform>().localScale = new Vector3(0.4f, background2.GetComponent<RectTransform>().localScale.y, background2.GetComponent<RectTransform>().localScale.z);
			story3.Begin();

			drinkCount++;
		}

		else if (drinkCount == 1)
		{
			//dialogue gave second drink to Gustav
			twinePlayer3.GetComponent<TwineTextPlayer>().AutoDisplay = true;
       		twinePlayer3.GetComponent<TwineTextPlayer>().StartStory = true;
       		background3.GetComponent<RectTransform>().localScale = new Vector3(0.4f, background2.GetComponent<RectTransform>().localScale.y, background2.GetComponent<RectTransform>().localScale.z);
			story3.Begin();

			drinkCount++;
		}

		else if (drinkCount == 2)
		{
			//dialogue when giving third drink to Stephan
			twinePlayer4.GetComponent<TwineTextPlayer>().AutoDisplay = true;
       		twinePlayer4.GetComponent<TwineTextPlayer>().StartStory = true;
       		background4.GetComponent<RectTransform>().localScale = new Vector3(0.4f, background2.GetComponent<RectTransform>().localScale.y, background2.GetComponent<RectTransform>().localScale.z);
			story4.Begin();

			drinkCount++;
		}

		else //drinkCount >= 3
		{
			//if stephan dead: dialogue end
			//else: give drink dialogue end

			//dialogue when giving final drink drink,*check if object dead
			twinePlayer5.GetComponent<TwineTextPlayer>().AutoDisplay = true;
       		twinePlayer5.GetComponent<TwineTextPlayer>().StartStory = true;
       		background5.GetComponent<RectTransform>().localScale = new Vector3(0.4f, background2.GetComponent<RectTransform>().localScale.y, background2.GetComponent<RectTransform>().localScale.z);
			story5.Begin();

		}
		

	}

	public void StartStory2()
	{
		twinePlayer2.GetComponent<TwineTextPlayer>().AutoDisplay = true;
       	twinePlayer2.GetComponent<TwineTextPlayer>().StartStory = true;
       	background2.GetComponent<RectTransform>().localScale = new Vector3(0.4f, background2.GetComponent<RectTransform>().localScale.y, background2.GetComponent<RectTransform>().localScale.z);
		story2.Begin();
	}

    // Update is called once per frame 
    void Update () {
		//if the intro block is done
		if (twinePlayer1.GetComponent<TwineTextPlayer>().StartStory && story1.CurrentPassage.Name == "Exit Gustav" && Input.GetKeyDown(KeyCode.Mouse0))
		{
			passageOneDone = true;
			gus.GetComponent<AnimationManager>().RotateAndWalk(0, Direction.right, 2);
			Invoke("StartStory2", 2f);
		}

		if (twinePlayer2.GetComponent<TwineTextPlayer>().StartStory && story2.CurrentPassage.Name == "Start" && Input.GetKeyDown(KeyCode.Mouse0))
		{
			//transitions to the next block of dialogue in game;
			twinePlayer2.SetActive(false);
			twinePlayer2.GetComponent<TwineTextPlayer>().StartStory = false;

			//enable the mixer to mix drink
			mixer.GetComponent<mixer>().StartDeliverCheck();
		}


		//we finished the intro block, moving onto the next block of dialogue.
		//for effeciency, turn this block into a switch statement. (Maybe)
		if (passageOneDone)
		{
			//transitions to the next block of dialogue in game
			passageOneDone = false;
			twinePlayer1.SetActive(false);
			twinePlayer1.GetComponent<TwineTextPlayer>().StartStory = false;
		}
	}
}
