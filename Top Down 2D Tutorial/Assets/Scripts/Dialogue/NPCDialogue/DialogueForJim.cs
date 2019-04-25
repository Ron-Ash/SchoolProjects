using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueForJim : MonoBehaviour {

    private ModalPanel modalPanel;

    private UnityAction yesEvent;
    private UnityAction noEvent;
    private UnityAction cancelEvent;

    private Text NPCText;
    private GameObject health_stamina_bars;
    Health_Stamina health_stamina;

    void Awake()
    {
        health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
        NPCText = GameObject.Find("PersonalDialogue").GetComponent<Text>();

        modalPanel = ModalPanel.Instance();

        yesEvent = new UnityAction(Yes);
        noEvent = new UnityAction(No);
        cancelEvent = new UnityAction(Cancel);
    }

    public void Interact()
    {
        modalPanel.Choice("who are you!!! who am I!!! \n PLEASE I BEG OF YOU... END MY SUFFERING!!!", yesEvent, noEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "Alright, if that's what you really want";
        modalPanel.button2.GetComponentInChildren<Text>().text = "No";
    }

    void Yes()
    {
        NPCText.text = "<MISSION> \n End Jim's suffering";
        modalPanel.closePanel();
        Destroy(GetComponent<DialogueForJim>());
        health_stamina.coin += 100;
    }

    void No()
    {
        modalPanel.Choice("PLEAES... I'll give you $100", yesEvent, cancelEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "alright";
        modalPanel.button2.GetComponentInChildren<Text>().text = "No";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

    void Cancel()
    {
        NPCText.text = "a poor soul, only if i could help him";
        modalPanel.closePanel();
        Destroy(GetComponent<DialogueForJim>());
    }
}
