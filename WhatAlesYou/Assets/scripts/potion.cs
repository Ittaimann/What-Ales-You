using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour {
	public string content;
    public AudioClip hitSE;
    // Use this for initialization

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(hitSE, transform.position);
    }

}
