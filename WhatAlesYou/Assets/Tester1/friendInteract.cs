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

	//when u click on friend, this object will pop up the dialogue.
	//if friend is talking, the dialogue box will pop up once and 
	//twine will take over.
	void OnMouseDown()
	{
		//set bool to true to allow only one click to start dialogue.
		if (isFriendTalking == false)
		{
			isFriendTalking = true;

			//code block that pops up dialogue and runs twine dialogue.
			twinePlayer.GetComponent<TwineTextPlayer>().AutoDisplay = true;
			twinePlayer.GetComponent<TwineTextPlayer>().StartStory = true;
			background.GetComponent<RectTransform>().localScale = new Vector3(0.8f, background.GetComponent<RectTransform>().localScale.y, background.GetComponent<RectTransform>().localScale.z);

			if (twinePlayer.GetComponent<TwineTextPlayer>().AutoDisplay)
			{
				twinePlayer.GetComponent<TwineTextPlayer>().Story.Begin();
			}
		}
	}
	
	// Update is called once per frame 
	void Update () {

	}
}
