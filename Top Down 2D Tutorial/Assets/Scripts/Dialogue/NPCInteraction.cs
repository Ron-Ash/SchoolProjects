using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{

    private GameObject NPC;
    private DialogueForJeff dialogueForJeff;
    private DialogueForGeorge dialogueForGeorge;
    private DialogueForPortal dialogueForPortal;
    private DialogueForJim dialogueForJim;
    private DialogueForHanWen dialogueForHanWen;
    private DialogueForBob dialogueForBob;
    private DialogueForOscar dialogueForOscar;
    private Text NPCText;
    public Sprite characterImage;
    public Image InterfaceImage;

    void Start()
    {
        NPCText = GameObject.Find("PersonalDialogue").GetComponent<Text>();
    }

    void OnMouseDown()
    {
        Invoke("Dialogue", 0.1f);
    }

    void Dialogue()
    {
        if (gameObject.name == "Oscar")
        {   
            gameObject.AddComponent<DialogueForOscar>();
            dialogueForOscar = gameObject.GetComponent<DialogueForOscar>();
            dialogueForOscar.Interact();
            InterfaceImage.GetComponent<Image>().sprite = characterImage;
        }
        else if (gameObject.name == "Jeff")
        {
            gameObject.AddComponent<DialogueForJeff>();
            dialogueForJeff = gameObject.GetComponent<DialogueForJeff>();
            dialogueForJeff.Interact();
            InterfaceImage.GetComponent<Image>().sprite = characterImage;
        }
        else if (gameObject.name == "Jim")
        {
            gameObject.AddComponent<DialogueForJim>();
            dialogueForJim = gameObject.GetComponent<DialogueForJim>();
            dialogueForJim.Interact();
            InterfaceImage.GetComponent<Image>().sprite = characterImage;
        }
        else if(gameObject.name == "HanWen")
        {
            gameObject.AddComponent<DialogueForHanWen>();
            dialogueForHanWen = gameObject.GetComponent<DialogueForHanWen>();
            dialogueForHanWen.Interact();
            InterfaceImage.GetComponent<Image>().sprite = characterImage;
        }
        else if(gameObject.name == "Bob")
        {
            gameObject.AddComponent<DialogueForBob>();
            dialogueForBob = gameObject.GetComponent<DialogueForBob>();
            dialogueForBob.Interact();
            InterfaceImage.GetComponent<Image>().sprite = characterImage;
        }
        else if (gameObject.name == "George")
        {
            gameObject.AddComponent<DialogueForGeorge>();
            dialogueForGeorge = gameObject.GetComponent<DialogueForGeorge>();
            dialogueForGeorge.Interact();
            InterfaceImage.GetComponent<Image>().sprite = characterImage;
        }
        else if (gameObject.name == "Portal")
        {
            gameObject.AddComponent<DialogueForPortal>();
            dialogueForPortal = gameObject.GetComponent<DialogueForPortal>();
            dialogueForPortal.Interact();
            InterfaceImage.GetComponent<Image>().sprite = characterImage;
        }
        else
        {
            NPCText.text = "He doesn't seem freindly, better stay away";
        }
    }
}
