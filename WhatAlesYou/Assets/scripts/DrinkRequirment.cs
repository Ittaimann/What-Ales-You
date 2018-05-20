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
			gameObject.GetComponent<friendInteract>().gaveDrink();
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
		info.Add("Potion", drink.ingredient1);
		info.Add("Apple", drink.ingredient2);
		info.Add("Sth", drink.ingredient3);
		info.Add("4", drink.ingredient4);
		info.Add("5", drink.ingredient5);

		return info;
	}

}

[System.Serializable]
public class DrinkInfo
{
	public int ingredient1 = 0;
	public int ingredient2 = 0;
	public int ingredient3 = 0;
	public int ingredient4 = 0;
	public int ingredient5 = 0;

}