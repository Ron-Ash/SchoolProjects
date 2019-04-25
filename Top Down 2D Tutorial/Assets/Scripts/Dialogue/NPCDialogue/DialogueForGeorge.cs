using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueForGeorge : MonoBehaviour {

	private ModalPanel modalPanel;

	private UnityAction yesEvent;
	private UnityAction noEvent;
	private UnityAction cancelEvent;
	private UnityAction noEvent2;
	
	private Text NPCText;

	void Awake()
	{
		NPCText = GameObject.Find("PersonalDialogue").GetComponent<Text>();

		modalPanel = ModalPanel.Instance();

		yesEvent = new UnityAction(Yes);
		noEvent = new UnityAction(No);
		cancelEvent = new UnityAction(Cancel);
	}

	public void Interact()
	{
		modalPanel.Choice("...", yesEvent, noEvent, cancelEvent);
		modalPanel.button1.GetComponentInChildren<Text>().text = "what happened...";
		modalPanel.button2.GetComponentInChildren<Text>().text = "are you alright old man";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "forget it";
    }
	
	void Yes()
	{
        modalPanel.Choice("I dont know much apart from the fact that something terrible happened. On the night before all this happened, a bright flash of light that enghlightened my room and woke me up. I dont know anything else", noEvent, noEvent, cancelEvent);
		modalPanel.cancelButton.GetComponentInChildren<Text>().text = "thank you, I'll leave you in peace now";
		modalPanel.button2.GetComponentInChildren<Text>().text = "no, i need more. \n Do you have more information?";
        modalPanel.button1.GetComponentInChildren<Text>().text = "are you sure what you saw was real?";
    }

	void No()
	{
		modalPanel.Choice("No!!!", Interact, yesEvent, cancelEvent);
		modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Ok, geez I'll leave";
		modalPanel.button1.GetComponentInChildren<Text>().text = "ok im sorry";
        modalPanel.button2.GetComponentInChildren<Text>().text = "What happened";
	}

	void Cancel()
	{
		NPCText.text = "what a strange person";
		modalPanel.closePanel();
		Destroy(GetComponent<DialogueForGeorge>());
    }
}
