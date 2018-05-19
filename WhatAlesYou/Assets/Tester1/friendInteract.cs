using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class friendInteract : MonoBehaviour {

	public GameObject twinePlayer;
	public GameObject background;

	public bool isFriendTalking = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame 
	void Update () {
		
		//when u click on friend (fix later)
		//set bool to true to allow only one click to start dialogue
		if (Input.GetMouseButtonDown(0))
		{
			if (isFriendTalking == false)
			{
				isFriendTalking = true;
				twinePlayer.GetComponent<TwineTextPlayer>().AutoDisplay = true;
				twinePlayer.GetComponent<TwineTextPlayer>().StartStory = true;

				//background.GetComponent<Image> -> sue for color later on
				Vector3 textBox = new Vector3(0.8f, background.GetComponent<RectTransform>().localScale.y, background.GetComponent<RectTransform>().localScale.z);
				background.GetComponent<RectTransform>().localScale = textBox;


				if (twinePlayer.GetComponent<TwineTextPlayer>().AutoDisplay)
				{
					twinePlayer.GetComponent<TwineTextPlayer>().Story.Begin();
				}
			}
		} 
	}
}
