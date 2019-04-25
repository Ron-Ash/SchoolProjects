using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour {

	private Text NPCText;

	void Start()
	{
		NPCText = GameObject.Find("PersonalDialogue").GetComponent<Text>();
	}

	void OnMouseDown()
    {
		NPCText.text = gameObject.name + " : " + gameObject.tag;
    }
}
