using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueForJeff : MonoBehaviour {

	private ModalPanel modalPanel;

	private UnityAction yesEvent;
	private UnityAction noEvent;
    private UnityAction noEvent4;
    private UnityAction cancelEvent2;
    private UnityAction cancelEvent;
    private UnityAction yesEvent3;
    private UnityAction yesEvent2;
	private UnityAction noEvent2;
    private UnityAction destroyPortalEvent;
    private UnityAction noEvent3;

    private Text NPCText;
	private GameObject health_stamina_bars;
	Health_Stamina health_stamina;

	void Awake()
	{
		health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
		NPCText = GameObject.Find("PersonalDialogue").GetComponent<Text>();

		modalPanel = ModalPanel.Instance();
        destroyPortalEvent = new UnityAction(destroyportal);

        yesEvent = new UnityAction(Yes);
        noEvent = new UnityAction(No);
		cancelEvent = new UnityAction(Cancel);
        cancelEvent2 = new UnityAction(Cancel2);
        yesEvent2 = new UnityAction(Yes2);
        yesEvent3 = new UnityAction(Yes3);
        noEvent2 = new UnityAction(No2);
        noEvent4 = new UnityAction(No4);
        noEvent3 = new UnityAction(No3);
    }

	public void Interact()
	{
		modalPanel.Choice("WHO ARE YOU?, are you here to figh or to buy?", yesEvent, noEvent, cancelEvent);
		modalPanel.button1.GetComponentInChildren<Text>().text = "Im here because Bob told me you can tell me what happened and how this town works";
		modalPanel.button2.GetComponentInChildren<Text>().text = "what happened here";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }
	
	void Yes()
	{
		modalPanel.Choice("Ah yes... well if you want to survive, you need the 5 main necessities for life in this town; \n - FOOD \n - WEAPONS \n -PROTECTION \n But most importantly, youll need money...", yesEvent2, noEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "Ok. where do i get these from?";
        modalPanel.button2.GetComponentInChildren<Text>().text = "what happened to this place";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

    void No()
	{
		modalPanel.Choice("I am not too sure, they have been strange flash lights and strange people has started to emerge, killing people all over the town and eating their brains", yesEvent, noEvent3, cancelEvent);
		modalPanel.button1.GetComponentInChildren<Text>().text = "thats horrible, can you help me Bob told me you can";
		modalPanel.button2.GetComponentInChildren<Text>().text = "where have the flashes been coming from?";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

	void Cancel()
	{
		NPCText.text = "what a starnge person";
		modalPanel.closePanel();
		Destroy(GetComponent<DialogueForJeff>());
    }

	void Yes2()
	{
        modalPanel.Choice("you can find food on the ground or from the store on the south side of the town. for fire power youll need to talk of Bob or Oscar for those high power, military grade weaponry. \n you can find some cents on the ground but mostly you can get them from corpses", cancelEvent, noEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "ok, thanks i'll leave you be now";
        modalPanel.button2.GetComponentInChildren<Text>().text = "ok, do you know what hapened here";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

	void No2()
	{
        health_stamina.coin += 300;
		modalPanel.closePanel();
		Destroy(GetComponent<DialogueForJeff>());
        NPCText.text = "<MISSION> \n explore power plswant";
    }

    void No3()
    {
        modalPanel.Choice("they came from the electricity plant. \n go investigate and I'll pay you well... how about $300?", noEvent2, cancelEvent, yesEvent3);
        modalPanel.button1.GetComponentInChildren<Text>().text = "<Accept Jeff's mission to explore the power plant>";
        modalPanel.button2.GetComponentInChildren<Text>().text = "<decline his offer>";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "<tell Jeff what you saw>";

    }

    void Yes3()
    {
        modalPanel.Choice("What did you see in there?", noEvent4, destroyPortalEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "there was nothing there just a bunch of rubish and destroyed electrical wires";
        modalPanel.button2.GetComponentInChildren<Text>().text = "There was a portal there, and zobies were coming out of it";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

    void No4()
    {
        modalPanel.Choice("No thats not possible I know what i saw", cancelEvent, destroyPortalEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "well i dont know what to tell you except goodbye and goodluck";
        modalPanel.button2.GetComponentInChildren<Text>().text = "There was a portal there, and zobies were coming out of it";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

    void destroyportal()
    {
        modalPanel.Choice("ho lord i hoped it wouldnt be like that, you must destroy it. Go to oscar and buy his secret weapon. here is some money \n HURRY...", cancelEvent2, cancelEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "I'll go to him at once";
        modalPanel.button2.GetComponentInChildren<Text>().text = "no thanks old man I need to get out of heare";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

    void Cancel2()
    {
        health_stamina.coin += 10000;
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
        modalPanel.closePanel();
        Destroy(GetComponent<DialogueForJeff>());
        NPCText.text = "<MISSION> \n go to oscar and buy the secret weapon";
    }
}