using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public GameObject health_stamina_bars;
    Health_Stamina health_stamina;
    public GameObject weapons;
    WeaponSwiching weaponSwitching;
    public Collider2D playerCollider;
    public int HealthBoost;
    public int StaminaBoost;
    public int Coin;
    public int SheildBoost;
    public bool trueBoost;
    public int ammo;

    void Start()
    {
        health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if(Input.GetButtonDown("PickUp") && coll.gameObject.tag == "Player")
        {
            weapons = GameObject.FindGameObjectWithTag("WeaponsCase");
            weaponSwitching = weapons.GetComponent<WeaponSwiching>();

            health_stamina.currentHealth += HealthBoost;
            

            health_stamina.currentStamina += StaminaBoost;

            health_stamina.currentShield += SheildBoost;

            health_stamina.coin += Coin;

            weaponSwitching.ammo += ammo;

            

            if(trueBoost == true)
            {
                health_stamina.maxHealth += HealthBoost;
                health_stamina.maxStamina += StaminaBoost;
                health_stamina.maxShield += SheildBoost;
            }
            Destroy(this.gameObject);
        }
    }
}
