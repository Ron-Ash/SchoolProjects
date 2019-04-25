using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueForOscar : MonoBehaviour {

    private ModalPanel modalPanel;

    private UnityAction yesEvent;
    private UnityAction noEvent;
    private UnityAction cancelEvent;
    private UnityAction noEvent2;
    private UnityAction Shotgun;
    private UnityAction Handgun;
    private UnityAction Assualtrifle;

    private UnityAction Shotgun_gun;
    private UnityAction semiAutoShotgun_gun;
    private UnityAction Glock_gun;
    private UnityAction Pistol_gun;
    private UnityAction Revolver_gun;
    private UnityAction M16_gun;
    private UnityAction AK47_gun;
    private UnityAction DOW_gun; 


    private Text NPCText;
    private GameObject health_stamina_bars;
    Health_Stamina health_stamina;
    Guns guns;

    void Awake()
    {
        health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
        guns = this.gameObject.GetComponent<Guns>();

        NPCText = GameObject.Find("PersonalDialogue").GetComponent<Text>();

        modalPanel = ModalPanel.Instance();

        yesEvent = new UnityAction(Yes);
        noEvent = new UnityAction(No);
        noEvent2= new UnityAction(No2);
        cancelEvent = new UnityAction(Cancel);
        Shotgun = new UnityAction(shotgun);
        Handgun = new UnityAction(handgun);
        Assualtrifle = new UnityAction(assualtrifle);

        Shotgun_gun = new UnityAction(ShotgunGun);
        semiAutoShotgun_gun = new UnityAction(SemiAutoShotGunGun);
        Glock_gun = new UnityAction(GlockGun);
        Pistol_gun = new UnityAction(PistolGun);
        M16_gun = new UnityAction(M16Gun);
        AK47_gun = new UnityAction(AK47Gun);
        DOW_gun = new UnityAction(DOWgun);
    }

    public void Interact()
    {
        modalPanel.Choice("Welcome to Oscar's place of weapons. how may i help you?", yesEvent, noEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "what is the secret weapon? Jeff told me you sell its";
        modalPanel.button2.GetComponentInChildren<Text>().text = "what weapons do you sell weapons?";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "forget it";
    }

    void Yes()
    {
        modalPanel.Choice("He wasnt supposed to tell anyone... but because you alreadyy know it wont hurt if you will understand it fully. \n it is a magical object that was thrown out of the portal at the power plant when it was created. it has a range of 5000 and does 5000 damage and im pretty sure it can go through walls \n I cal it the 'DOW' Destroyer Of Worlds. its a priceless artifact", noEvent2, noEvent, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "How much is it?";
        modalPanel.button2.GetComponentInChildren<Text>().text = "what other weapons do you sell?";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "thank you but im alright";
    }

    void No2 ()
    {
        modalPanel.Choice("$10,000 \n but you have to promise me one thing. KILL that evil portal, dont talk to him he will desive you and you will die", noEvent, DOW_gun, cancelEvent);
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
        modalPanel.button1.GetComponentInChildren<Text>().text = "what other weapons do you sell?";
        modalPanel.button2.GetComponentInChildren<Text>().text = "Allright here are the 10000";
    }

    void DOWgun()
    {
        if (health_stamina.coin >= 10000)
        {
            health_stamina.coin -= 10000;
            Instantiate(guns.DOWOb, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Cancel();
        }
        else
        {
            Cancel();
            NPCText.text = "need more cash";
        }
    }

    void No()
    {
        modalPanel.Choice("Alright then have a look", Handgun, Shotgun, Assualtrifle);
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Assault Rifles";
        modalPanel.button1.GetComponentInChildren<Text>().text = "Granade Launcher";
        modalPanel.button2.GetComponentInChildren<Text>().text = "Sniper rifles";
    }

    void Cancel()
    {
        NPCText.text = "remember, bob sells guns";
        modalPanel.closePanel();
        Destroy(GetComponent<DialogueForGeorge>());
    }

    void shotgun()
    {
        modalPanel.Choice("with a rage of 100, you will get any zombie you want \n So which one would you like?", Shotgun_gun, semiAutoShotgun_gun, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "Sniper - $300";
        modalPanel.button2.GetComponentInChildren<Text>().text = "Semi-Auto sniper - $500";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

    void handgun()
    {
        modalPanel.Choice("Good choice \n So which one would you like?", Glock_gun, Pistol_gun, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "Semi-Auto granade launcher - $1000";
        modalPanel.button2.GetComponentInChildren<Text>().text = "missile launcher - $2000";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

    void assualtrifle()
    {
        modalPanel.Choice("Well here are some of my rifles, straight from vietnam they are the best of the best upto 50 meters \n So which one would you like?", M16_gun, AK47_gun, cancelEvent);
        modalPanel.button1.GetComponentInChildren<Text>().text = "M-16 - $400";
        modalPanel.button2.GetComponentInChildren<Text>().text = "Ak-47 - $500";
        modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
    }

    void ShotgunGun()
    {
        if (health_stamina.coin >= 300)
        {
            health_stamina.coin -= 300;
            Instantiate(guns.shotgunOb, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        else
        {
            Cancel();
            NPCText.text = "need more cash";
        }
    }

    void SemiAutoShotGunGun()
    {
        if (health_stamina.coin >= 500)
        {
            health_stamina.coin -= 500;
            Instantiate(guns.semiautoshotgunOb, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        else
        {
            Cancel();
            NPCText.text = "need more cash";
        }
    }

    void GlockGun()
    {
        if (health_stamina.coin >= 1000)
        {
            health_stamina.coin -= 1000;
            Instantiate(guns.glockOb, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Cancel();
        }
        else
        {
            Cancel();
            NPCText.text = "need more cash";
        }
    }

    void PistolGun()
    {
        if (health_stamina.coin >= 2000)
        {
            health_stamina.coin -= 2000;
            Instantiate(guns.pistolOb, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Cancel();
        }
        else
        {
            Cancel();
            NPCText.text = "need more cash";
        }
    }

    void M16Gun()
    {
        if (health_stamina.coin >= 400)
        {
            health_stamina.coin -= 400;
            Instantiate(guns.m16Ob, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Cancel();
        }
        else
        {
            Cancel();
            NPCText.text = "need more cash";
        }
    }

    void AK47Gun()
    {
        if (health_stamina.coin >= 500)
        {
            health_stamina.coin -= 500;
            Instantiate(guns.ak47Ob, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Cancel();
        }
        else
        {
            Cancel();
            NPCText.text = "need more cash";
        }
    }
}
