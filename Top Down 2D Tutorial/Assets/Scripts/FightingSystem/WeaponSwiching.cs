using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwiching : MonoBehaviour {

	public int selectedWeapon = 0;
	public Text weaponName;
	public Text weaponStats;
	WeaponsStatsPickUp weaponsStatsPickUp;
	public float attackRate;
	public float damage;
	public float range;
	public bool melee;
    public bool semiAuto;
    public bool auto;
    public bool reload;
    public int ammo;
    public Collider2D weaponCollider;
    [SerializeField] AudioSource switchingSound;

    void Start () 
	{
		selectWeapon();
	}

	void LateUpdate () 
	{
        weaponStats.text = damage + " | " + ammo ;
        ChangingWeapon();
	}

    void ChangingWeapon()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetKeyDown(KeyCode.P))
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
        }
    }


    void selectWeapon()
	{
        switchingSound.Play();
        int i = 0;
		foreach (Transform weapon in transform)
		{

			if(i == selectedWeapon)
			{
				weapon.gameObject.SetActive(true);
				weaponName.text = weapon.gameObject.name;
				weaponsStatsPickUp = weapon.gameObject.GetComponent<WeaponsStatsPickUp>();
				
				weaponCollider = weaponsStatsPickUp.weaponCollider;
				attackRate = weaponsStatsPickUp.attackRate;
				damage = weaponsStatsPickUp.damage;
				range = weaponsStatsPickUp.range;
				melee = weaponsStatsPickUp.melee;
                semiAuto = weaponsStatsPickUp.semiAuto;
                auto = weaponsStatsPickUp.auto;
                reload = weaponsStatsPickUp.reload;
                ammo = weaponsStatsPickUp.ammo;
				weaponCollider.enabled = false;
	
			}
			else
			{
				weapon.gameObject.SetActive(false);
			}
			i++;
		}
	}
}
