using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationManager : MonoBehaviour {
	
	public void Start()
	{
		SitDown();
	}

	public void SitDown()
	{
		GetComponent<Animator>().SetBool("IsSitting", true);
	}

}
