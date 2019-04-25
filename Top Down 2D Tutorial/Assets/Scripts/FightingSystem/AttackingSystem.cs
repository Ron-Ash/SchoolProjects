using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingSystem : MonoBehaviour {

	public GameObject weaponsCase;
	WeaponSwiching weaponSwiching;
    Health health;
	public GameObject health_stamina_bars;
	Health_Stamina health_stamina;
	public bool shield;
	private bool attacking;
    public GameObject projectile;
    public Transform firePosition;
    public AudioSource gunSoundSource;
    public AudioSource enemyhitsound;

    void Start () 
	{
		health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
		weaponsCase = GameObject.FindGameObjectWithTag("WeaponsCase");
		weaponSwiching = weaponsCase.GetComponent<WeaponSwiching>();
		shield = false;

    }

    void FixedUpdate()
	{
        Shoot();
        Shield();	
	}

	void OnTriggerStay2D(Collider2D coll)
	{
		
		if(weaponsCase.transform.childCount > 0)
		{
            if (!Input.GetKey(KeyCode.LeftShift) && shield == false && coll.gameObject.tag == "CanAttack" )
			{
                health = coll.gameObject.GetComponent<Health>();

                if (Input.GetButtonDown("Fire") && health_stamina.currentStamina > 0  && attacking == false)
				{
					attacking = true;
					Melee();
				}
			}
		}
	}

	void Melee()
	{
		Debug.Log("swing...swoosh");
		health.health -= weaponSwiching.damage;
		health_stamina.currentStamina -= weaponSwiching.damage;
		Invoke("EndingAttack", weaponSwiching.attackRate);
	}

    void Shooting()
    {
        gunSoundSource.Play();
        Debug.Log("pew...pew");
        attacking = true;
        weaponSwiching.ammo -= 1;
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePosition.position.x, firePosition.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, weaponSwiching.range);

        if(hit.collider != null)
        {
            health = hit.collider.gameObject.GetComponent<Health>();
            if (hit.collider.gameObject.tag == "CanAttack")
            {
                enemyhitsound.Play();
                health.health -= weaponSwiching.damage;
            }
        }
        Instantiate(projectile, firePosition.position, firePosition.rotation);
        Invoke("EndingAttack", weaponSwiching.attackRate);
    }

    void EndingAttack()
    {
        Debug.Log("Attack now!!!");
        attacking = false;
    }

    void Reload()
    {
        weaponSwiching.reload = true;

    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (weaponSwiching.auto == true && weaponSwiching.semiAuto == false && weaponSwiching.melee == false && attacking == false && shield == false && weaponSwiching.ammo != 0)
        {
            if (Input.GetButton("Fire"))
            {
                Shooting();
            }
        }
        else if (weaponSwiching.auto == false && weaponSwiching.semiAuto == true && weaponSwiching.melee == false && attacking == false && shield == false && weaponSwiching.ammo != 0)
        {
            if (Input.GetButtonDown("Fire"))
            {
                Shooting();
            }
        }
        else if (weaponSwiching.semiAuto == false && weaponSwiching.melee == false && attacking == false && shield == false && weaponSwiching.auto == false && weaponSwiching.ammo != 0)
        {
            if (weaponSwiching.reload == true)
            {
                if (Input.GetButtonDown("Fire"))
                {
                    Shooting();
                    weaponSwiching.reload = false;
                }
            }
        }
    }

    void Shield()
    {
        if (Input.GetMouseButton(1) && health_stamina.currentShield > 0)
        {
            shield = true;
            Debug.Log("Defence On");
        }
        else
        {
            shield = false;
            Debug.Log("Defence Off");
        }
    }
}
