using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkRequirment : MonoBehaviour {
	public DrinkInfo[] quests;
	private int index = 0;
	// Use this for initialization
	
	public void ProcessDrink(Dictionary<string, int> drink)
	{
		if(index < quests.Length)
		{
			Dictionary<string, int> requirement = ToDrinkDict(quests[index]);
			int score = CalculatScore(drink, requirement);
			++index;
			//continue the story by the score
			Debug.Log(score);
		}
		
	}

	private int CalculatScore(Dictionary<string, int> drink, Dictionary<string, int> required)
	{
		int score = 10;
		foreach(string key in required.Keys)
		{
			if(drink.ContainsKey(key))
			{
				score -= (required[key] - drink[key]);
			}else{
				score -= required[key];
			}
		}
		return score;
	}

	private Dictionary<string, int> ToDrinkDict(DrinkInfo drink)
	//get a dictionary and translate that to a drinkInfo
	{
		Dictionary<string, int> info = new Dictionary<string, int>();
		info.Add("Potion", drink.indigrent1);
		info.Add("Apple", drink.indigrent2);
		info.Add("Sth", drink.indigrent3);
		info.Add("4", drink.indigrent4);
		info.Add("5", drink.indigrent5);

		return info;
	}

}

[System.Serializable]
public class DrinkInfo
{
	public int indigrent1 = 0;
	public int indigrent2 = 0;
	public int indigrent3 = 0;
	public int indigrent4 = 0;
	public int indigrent5 = 0;

}