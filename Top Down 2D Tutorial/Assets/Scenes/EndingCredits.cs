using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCredits : MonoBehaviour {
    [SerializeField]
    AudioClip OpeningScenClip;
    [SerializeField]
    AudioSource OpeningSceneAudio;
    public GameObject title;
    public GameObject credits;
    bool toStart;
    
    // Use this for initialization
	void Start () {
        OpeningSceneAudio.Play();
        title.SetActive(false);
        toStart = false;
        Invoke("ActivateCredits", 8.1f);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }

		if(toStart == true)
        {
            credits.transform.Translate(0, transform.position.y + 1, 0);
        }
	}

    void ActivateCredits()
    {
        title.SetActive(true);
        Invoke("CreditsScroll", 3);
    }

    void CreditsScroll()
    {
        toStart = true;
    }
}
