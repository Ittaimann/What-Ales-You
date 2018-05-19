using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixer : MonoBehaviour {
	private List<string> contents = new List<string>();
	private bool checkAdding = false;//if should check should or should not add potion
	// Use this for initialization
	public void AddContent(string contentName)
	{
		contents.Add(contentName);
	}
	public void CleanContent(string contentName)
	{
		contents.Clear();
	}
	
	public List<string> GetContent(string contentName)
	{
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
			AddContent(other.gameObject.GetComponent<potion>().content);
			other.gameObject.GetComponent<drag>().OnMouseUp();
			Debug.Log(contents.Count);
			checkAdding = false;
		}
	}

	public void OnTriggerExit(Collider other)
	{
		checkAdding = false;
	}

}
