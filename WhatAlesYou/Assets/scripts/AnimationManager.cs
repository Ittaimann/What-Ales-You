using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
	left,
	right
}
public class AnimationManager : MonoBehaviour {
	public void Start()
	{

	}

	public IEnumerator Test()
	{
		SitDown();
		yield return new WaitForSeconds(1f);
		StandUp();
		yield return new WaitForSeconds(1f);
		Greet();
		yield return new WaitForSeconds(3f);
		Ashamed();
	}

	public void RotateAndWalk(float time1, Direction direction, float time2)
	{
		StartCoroutine(Rotating(time1, direction, time2));
	}

	/* 
	public void Rotate(Direction direction)
	{
		StartCoroutine(Rotating(0,direction,0));
	}*/

	public void WalkForward(float time)
	{
		StartCoroutine(Trigger("IsWalking", time));
	}
	public void SitDown()
	{
		GetComponent<Animator>().SetBool("IsSitting", true);
	}

	public void StandUp()
	{
		GetComponent<Animator>().SetBool("IsSitting", false);
	}
	public void Drink()
	{
		StartCoroutine(Trigger("IsDrinking", 0.1f));
	}

	public void Ashamed()
	{
		StartCoroutine(Trigger("IsAshamed", 0.1f));
	}

	public void NodeOnce()
	{
		StartCoroutine(Trigger("IsRefusing", 0.1f));
	}
	public void StartNodding()
	{
		GetComponent<Animator>().SetBool("IsRefusing", true);
	}

	public void StopNodding()
	{
		GetComponent<Animator>().SetBool("IsRefusing", false);
	}
	public void Embarrass()
	{
		StartCoroutine(Trigger("IsEmbarrassed", 0.1f));
	}
	
	public void Greet()
	{
		StartCoroutine(Trigger("IsGreeting", 0.1f));
	}

	public void Pose()
	{
		StartCoroutine(Trigger("IsPosing", 0.1f));
	}

	public void ResetBool()
	{
		GetComponent<Animator>().SetBool("IsWalking", false);
		GetComponent<Animator>().SetBool("IsEmbarrassed", false);
		GetComponent<Animator>().SetBool("TurnRight", false);
		GetComponent<Animator>().SetBool("TurnLeft", false);
		GetComponent<Animator>().SetBool("IsAshamed", false);
		GetComponent<Animator>().SetBool("IsRefusing", false);
		GetComponent<Animator>().SetBool("IsIdle", false);
		GetComponent<Animator>().SetBool("IsDrinking", false);
		GetComponent<Animator>().SetBool("IsGreeting", false);
		GetComponent<Animator>().SetBool("IsPosing", false);

	}

	private IEnumerator Trigger(string name, float time)
	{
		GetComponent<Animator>().SetBool(name, true);
		yield return new WaitForSeconds(time);
		GetComponent<Animator>().SetBool(name, false);
	}

	private IEnumerator Rotating(float beforeWalkTime, Direction direction, float afterWalkTime)
	{
		if(beforeWalkTime != 0)
			yield return Trigger("IsWalking", beforeWalkTime);
		Vector3 unit = new Vector3(0,1,0);
		if(direction == Direction.left)
		{
			unit = new Vector3(0,-1,0);
		}

		for(int x = 0; x< 90; ++x)
		{
			transform.Rotate(unit);
			yield return new WaitForSeconds(0.01f);
		}

		if(afterWalkTime != 0)
			yield return Trigger("IsWalking", afterWalkTime);
	}

}
