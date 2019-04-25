using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class Tester : MonoBehaviour {

	private ModalPanel modalPanel;

	private UnityAction yesEvent;
	private UnityAction noEvent;
	private UnityAction cancelEvent;


	void Awake()
	{
		modalPanel = ModalPanel.Instance();

		yesEvent = new UnityAction(Testbutton1);
		noEvent = new UnityAction(Testbutton2);
		cancelEvent = new UnityAction(TestCancel);
	}

	public void TestYNC()
	{
		modalPanel.Choice("Would you like a poke in the eye?\nHow about with a sharp stick?", yesEvent, noEvent, cancelEvent);
	}

	void Testbutton1()
	{
		Debug.Log("Heck yeah!!!");
	}

	void Testbutton2()
	{
		Debug.Log("NOOOO!!!");
	}

	void TestCancel()
	{
		Debug.Log("I give up");
	}
}
