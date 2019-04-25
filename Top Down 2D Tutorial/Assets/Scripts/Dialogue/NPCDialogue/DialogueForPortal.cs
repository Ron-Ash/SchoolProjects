using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class DialogueForPortal : MonoBehaviour
{

    private ModalPanel modalPanel;

    private UnityAction yesEvent;
    private UnityAction noEvent;
    private UnityAction cancelEvent;
    private UnityAction yesEvent2;
    private UnityAction cancelEvent2;

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

        yesEvent2 = new UnityAction(Yes2);
    }

    public void Interact()
    {
        modalPanel.Choice("Human!!! It Is I the destroyer of men Neal before me \n Become my pupol and I'll give you riches beyond your imagination", yesEvent, noEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "Oh Yes Might Ruler";
        modalPanel.button2.GetComponentInChildren<Text>().text = "NO";
        modalPanel.cancelButton.GetComponent<Text>().text = "Cancel";
    }

    void Yes()
    {
        modalPanel.Choice("Now my pupol, Under this power plant there is an underground bunker with enought nukes to destroy this discusting earth and everyone in it. \n Detinate it", yesEvent2, noEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "<Detonate the nukes>";
        modalPanel.button2.GetComponentInChildren<Text>().text = "NO";
        health_stamina.coin += 10000;
        health_stamina.maxHealth += 10000;
        health_stamina.maxStamina += 10000;
        health_stamina.maxShield += 10000;
    }

    void No()
    {
        modalPanel.Choice("Then You will DIE!!!!!!!!!!!!!", yesEvent2, yesEvent, cancelEvent);
        health_stamina.currentHealth -= 1000000000;
    }

    void Cancel()
    {
        modalPanel.closePanel();
        Destroy(GetComponent<DialogueForPortal>());
    }

    void Yes2()
    {
        SceneManager.LoadScene(4);
    }
}
