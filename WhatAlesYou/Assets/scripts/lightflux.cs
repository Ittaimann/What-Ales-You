using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightflux : MonoBehaviour {

	private Light lg;
	float start;
	void Awake()
	{
		lg=gameObject.GetComponent<Light>();
		lg.intensity=Random.Range(10,70);
		start=lg.intensity;
	}

	void Update()
	{
		Debug.Log((1+Mathf.Sin(Time.time))/2);
		lg.intensity=Mathf.Lerp(70,20, (1 + Mathf.Sin(Time.time)) / 2);
	}
}
