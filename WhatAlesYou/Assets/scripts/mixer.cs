using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixer : MonoBehaviour {
	private Dictionary<string, int> contents = new Dictionary<string, int>();
	private bool checkAdding = false;//if should check should or should not add potion
	// Use this for initialization

	public void Update()
	{
		//just for test
		if(Input.GetKeyDown(KeyCode.A))
		{
			GetContent();
			CleanContent();
		}
	}
	public void AddContent(string contentName)
	{
		if(!contents.ContainsKey(contentName))
		{
			contents.Add(contentName, 0);
		}
		++contents[contentName];
	}
	public void CleanContent()
	{
		contents.Clear();
	}
	
	public Dictionary<string, int> GetContent()
	{
		string test = "";
		foreach(string key in contents.Keys)
		{
			if(contents[key] > 0)
			{
				test += key + ":" + contents[key]+"\n";
			}
		}
		Debug.Log(test);
		return contents;
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Potion" && other.gameObject.GetComponent<drag>().GetStatus() == DragingStatus.draging)
		//a potion is dragged inside the mixer, keep an eye on it
		{
			checkAdding = true;
		}
	}

	public void OnTriggerStay(Collider other)
	{
		if(checkAdding && other.gameObject.GetComponent<drag>().GetStatus() == DragingStatus.returning)
		//Potion starts to return, means mouse up, add that to mixer and change potion's state
		{
			checkAdding = false;
			AddContent(other.gameObject.GetComponent<potion>().content);
			other.gameObject.GetComponent<drag>().OnMouseUp();
			Debug.Log("Add!");
			
		}
	}

	public void OnTriggerExit(Collider other)
	{
		checkAdding = false;
	}

}
