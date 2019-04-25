using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nukeEndingLoadingScrene : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        Invoke("loading3", 185);
	}
	

    void loading3()
    {
        SceneManager.LoadScene(2);
    }
}
