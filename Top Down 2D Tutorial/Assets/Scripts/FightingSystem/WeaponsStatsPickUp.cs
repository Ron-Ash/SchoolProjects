using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsStatsPickUp : MonoBehaviour {

	public float attackRate;
	public float damage;
	public float range;
	public bool melee;
    public bool semiAuto;
    public bool auto;
    public bool reload;
    public int ammo;
	public Collider2D weaponCollider;
	public Renderer weaponRenderer;
	public GameObject player;
    public Collider2D trigger;

	

	void Start() 
	{
		player = GameObject.FindGameObjectWithTag("WeaponsCase");
		transform.localScale = new Vector3(0.3f, 0.3f, 1);
		weaponRenderer.enabled = true;
	}
		
	void OnTriggerStay2D(Collider2D coll)
	{
		Debug.Log("collision");
		if(Input.GetButtonDown("PickUp") && coll.gameObject.tag == "Player")
		{
			Debug.Log("Player picked up "+ name);
			weaponRenderer.enabled = false;
			this.gameObject.transform.parent = player.transform;
		}
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameObject.name != "Fist")
        {
            trigger.enabled = true;
            weaponRenderer.enabled = true;
            this.gameObject.transform.parent = null;

        }
    }
}