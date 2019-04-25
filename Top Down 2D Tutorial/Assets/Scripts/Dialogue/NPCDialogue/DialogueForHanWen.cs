using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueForHanWen : MonoBehaviour
{

    private ModalPanel modalPanel;

    private UnityAction yesEvent;
    private UnityAction noEvent;
    private UnityAction cancelEvent;

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
        modalPanel.Choice("It is no longer safe here. Dont trust anyone!!! \n You need to protect yourself, head to Bob's he'll help you", yesEvent, noEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "Alright";
        modalPanel.button2.GetComponentInChildren<Text>().text = "I dont believe you";
    }

    void Yes()
    {
        NPCText.text = "<MISSION> \n Go to Bob's";
        modalPanel.closePanel();
        Destroy(GetComponent<DialogueForHanWen>());
    }

    void No()
    {
        modalPanel.Choice("You must, if you want to survive", yesEvent, cancelEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "alright to bob's it is";
        modalPanel.button2.GetComponentInChildren<Text>().text = "i think ill stay here thanks";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

    void Cancel()
    {
        NPCText.text = "that was strange, \n what happened to everyone";
        modalPanel.closePanel();
        Destroy(GetComponent<DialogueForHanWen>());
    }
}
