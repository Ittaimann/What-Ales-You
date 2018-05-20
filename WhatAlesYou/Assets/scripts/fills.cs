using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fills : MonoBehaviour {


	//List<Vector3> beerColors= new List<Vector3>(new Vector3(1,1,1));
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.SetFloat("_FillAmount",Random.Range(.15f,.95f));
        gameObject.GetComponent<Renderer>().material.SetFloat("_Rim", Random.Range(.01f, .1f));
        gameObject.GetComponent<Renderer>().material.SetFloat("_Rim", Random.Range(.01f, .1f));

    }
	
	// Update is called once per frame

}
