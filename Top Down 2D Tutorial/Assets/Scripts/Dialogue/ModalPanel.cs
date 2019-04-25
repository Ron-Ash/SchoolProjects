using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {

	public Text question;
	public Image iconImage;
	public Button button1;
	public Button button2;
	public Button cancelButton;
	public GameObject modalPanelObject;
    public bool dialogue;

	private static ModalPanel modalPanel;

	public static ModalPanel Instance()
	{
		if(!modalPanel)
		{
			modalPanel = FindObjectOfType(typeof (ModalPanel)) as ModalPanel;
			if(!modalPanel)
			{
				Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
			}
		}
		return modalPanel;
	}

	// Yes/No/Cancel: A string, a yes event, a no event, a cancel event
	public void Choice(string question , UnityAction Button1Action, UnityAction Button2Action, UnityAction calcelEvent)
	{
        dialogue = true;
        modalPanelObject.SetActive(true);
		this.question.text = question;
		this.iconImage.gameObject.SetActive(true);
		button1.gameObject.SetActive(true);
		button2.gameObject.SetActive(true);
		cancelButton.gameObject.SetActive(true);

		button1.onClick.RemoveAllListeners();
		button1.onClick.AddListener(Button1Action);

		button2.onClick.RemoveAllListeners();
		button2.onClick.AddListener(Button2Action);

		cancelButton.onClick.RemoveAllListeners();
		cancelButton.onClick.AddListener(calcelEvent);

	}

	public void closePanel()
	{
		modalPanelObject.SetActive(false);
        dialogue = false;
	}

}
