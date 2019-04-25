using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueForBob : MonoBehaviour {

        private ModalPanel modalPanel;

        private UnityAction yesEvent;
    private UnityAction yesEvent3;
        private UnityAction yesEvent2;
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
            yesEvent2 = new UnityAction(Yes2);
            yesEvent3 = new UnityAction(Yes3);
            noEvent = new UnityAction(No);
            cancelEvent = new UnityAction(Cancel);
            Shotgun = new UnityAction(shotgun);
            Handgun = new UnityAction(handgun);
            Assualtrifle = new UnityAction(assualtrifle);

            Shotgun_gun = new UnityAction(ShotgunGun);
            semiAutoShotgun_gun = new UnityAction(SemiAutoShotGunGun);
            Glock_gun = new UnityAction(GlockGun);
            Pistol_gun = new UnityAction(PistolGun);
            Revolver_gun = new UnityAction(RevolverGun);
            M16_gun = new UnityAction(M16Gun);
            AK47_gun = new UnityAction(AK47Gun);
    }

        public void Interact()
        {
            modalPanel.Choice("Welcome to Bob's Store for DEADLY weapons. how may i help you?", yesEvent, noEvent, cancelEvent);
            modalPanel.button1.GetComponentInChildren<Text>().text = "what happened";
            modalPanel.button2.GetComponentInChildren<Text>().text = "Do you sell weapons?";
            modalPanel.cancelButton.GetComponentInChildren<Text>().text = "forget it";
        }

        void Yes()
        {
            modalPanel.Choice("the streets are'nt safe anymore, the undead roam the streets. \n You need weaponry to protect yourself now, weaponry i can sell for a much affordable price. would you like to have a look?", noEvent, yesEvent2, cancelEvent);
            modalPanel.button1.GetComponentInChildren<Text>().text = "Yes, i can use the fire power";
            modalPanel.button2.GetComponentInChildren<Text>().text = "Im not that interested right now, do you know who is still left?";
            modalPanel.cancelButton.GetComponentInChildren<Text>().text = "thank you but im alright";
        }

        void No()
        {
            modalPanel.Choice("Alright then have a look", Handgun, Shotgun, Assualtrifle);
            modalPanel.cancelButton.GetComponentInChildren<Text>().text = "ASSAULT RIFLES";
            modalPanel.button1.GetComponentInChildren<Text>().text = "HANDGUNS";
            modalPanel.button2.GetComponentInChildren<Text>().text = "SHOTGUNS";
        }

        void Yes2()
        {
            modalPanel.Choice("Yes, go to jeff he'll know how to help", noEvent, yesEvent3, cancelEvent);
            modalPanel.button1.GetComponentInChildren<Text>().text = "Yes, i can use the fire power";
            modalPanel.button2.GetComponentInChildren<Text>().text = "Ill find him right away";
            modalPanel.cancelButton.GetComponentInChildren<Text>().text = "thank you but im alright";
        }

        void Yes3()
        {
        NPCText.text = "<MISSION>\nFind and talk to Jeff";
        modalPanel.closePanel();
        Destroy(GetComponent<DialogueForGeorge>());
        }

        void Cancel()
        {
            NPCText.text = "remember, bob sells guns";
            modalPanel.closePanel();
            Destroy(GetComponent<DialogueForGeorge>());
        }

        void shotgun()
        {
            modalPanel.Choice("a good choice if you are in teh zombie killing buisness and teh best friend youll ever want for 15 meter combat \n So which one would you like?", Shotgun_gun, semiAutoShotgun_gun, cancelEvent);
            modalPanel.button1.GetComponentInChildren<Text>().text = "Shotgun - $75";
            modalPanel.button2.GetComponentInChildren<Text>().text = "Semi-Auto Shotgun - $150";
            modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
        }

        void handgun()
        {
            modalPanel.Choice("Well here are some of my finest handguns, small, light and deadly for upto 10 meters \n So which one would you like?", Glock_gun, Pistol_gun, Revolver_gun);
            modalPanel.button1.GetComponentInChildren<Text>().text = "Glock - $50";
            modalPanel.button2.GetComponentInChildren<Text>().text = "Pistol - $10";
            modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Revolver - $25";
        }

        void assualtrifle()
        {
            modalPanel.Choice("Well here are some of my rifles, straight from vietnam they are the best of the best upto 50 meters \n So which one would you like?", M16_gun, AK47_gun, cancelEvent);
            modalPanel.button1.GetComponentInChildren<Text>().text = "M-16 - $250";
            modalPanel.button2.GetComponentInChildren<Text>().text = "Ak-47 - $300";
            modalPanel.cancelButton.GetComponentInChildren<Text>().text = "Cancel";
        }

        void ShotgunGun()
        {
            if(health_stamina.coin >= 75)
            {
                health_stamina.coin -= 75;
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
            if (health_stamina.coin >= 150)
            {
                health_stamina.coin -= 150;
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
            if (health_stamina.coin >= 50)
            {
                health_stamina.coin -= 50;
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
            if (health_stamina.coin >= 10)
            {
                health_stamina.coin -= 10;
                Instantiate(guns.pistolOb, this.gameObject.transform.position, this.gameObject.transform.rotation);
                Cancel();
            }
            else
            {
                Cancel();
                NPCText.text = "need more cash";
            }
        }

        void RevolverGun()
        {
            if (health_stamina.coin >= 25)
            {
                health_stamina.coin -= 25;
                Instantiate(guns.revolverOb, this.gameObject.transform.position, this.gameObject.transform.rotation);
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
            if (health_stamina.coin >= 250)
            {
                health_stamina.coin -= 250;
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
            if (health_stamina.coin >= 300)
            {
                health_stamina.coin -= 300;
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
