using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {

    Health health;
    // Use this for initialization
	void Start () {
        health = this.gameObject.GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
		if(health.health <= 0)
        {
            SceneManager.LoadScene(3);
        }
	}
}
