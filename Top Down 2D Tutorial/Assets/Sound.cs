using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public AudioSource backgroundmusic;
    // Use this for initialization
    void Awake () {
        backgroundmusic.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
