using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioForOpeningScene : MonoBehaviour {

    [SerializeField] AudioClip OpeningScenClip;
    [SerializeField] AudioSource OpeningSceneAudio;
    // Use this for initialization
	void Start () {
        OpeningSceneAudio.Play();
	}
}
