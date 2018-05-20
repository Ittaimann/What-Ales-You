using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixer : MonoBehaviour {
	private Dictionary<string, int> contents = new Dictionary<string, int>();
	private bool checkAdding = false;//if should check should or should not add potion
	private bool canDeliver = false;
	// Use this for initialization

	public void Update()
	{
		
	}
	
//========================================================================================================
//Modify Contents
//========================================================================================================

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

//========================================================================================================
//Check adding position
//========================================================================================================

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
		//Debug.Log(checkAdding && other.tag == "Potion");
		if(checkAdding && other.tag == "Potion" && other.gameObject.GetComponent<drag>().GetStatus() == DragingStatus.checking)
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
//========================================================================================================
//Deliver drink to customer
//========================================================================================================
	public void OnMouseUp()
	{
		if(canDeliver)
		{
			DeliverDrink();
			canDeliver = false;
		}
	}

	public void StartDeliverCheck()
	{
		canDeliver = true;
	}

	private void DeliverDrink()
	{
		RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		GetComponent<Collider>().enabled = false;
        if (Physics.Raycast(ray, out hit)) 
		{
			GameObject hitObject = hit.transform.gameObject;
            if (hitObject.tag == "Customer")
			{
 				GameObject.Find("Manager").GetComponent<DrinkRequirment>().ProcessDrink(GetContent());
				CleanContent();	
				canDeliver = false;
			}
		}
		GetComponent<Collider>().enabled = true;
	}

}
