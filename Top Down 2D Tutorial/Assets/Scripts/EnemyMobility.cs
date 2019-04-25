using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMobility : MonoBehaviour {

    //variables that will be able to be accessed from the Inspector 
    public float speed;
	public Transform player;
	public Rigidbody2D enemy;
	public float damage;
	public GameObject health_stamina_bars;
	Health_Stamina health_stamina;
	public Collider2D playerCollider;
	public GameObject playerGameObject;
    AttackingSystem attackingSystem;
    [SerializeField]public GameObject modalPanelObject;
    ModalPanel modalPanel;

	void Start () 
	{
        //connects the scrip to the healthbar objects, its scripts
        health_stamina_bars = GameObject.FindGameObjectWithTag("Health_Stamina");
        health_stamina = health_stamina_bars.GetComponent<Health_Stamina>();
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		attackingSystem = playerGameObject.GetComponent<AttackingSystem>();
        modalPanel = modalPanelObject.GetComponent<ModalPanel>();
        player = playerGameObject.transform;

	}	

	

	void FixedUpdate()
	{
        //will start if the player isnt talking to anyone
        if(modalPanel.dialogue == false)
        {
            //will follow the player in a rat edictated by the speed variable
            float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(0, 0, z);
            enemy.AddForce(gameObject.transform.up * speed);
        }
        else
        {
            Debug.Log("the zombies have stopped moving");
        }

	}

	void OnTriggerEnter2D(Collider2D coll)
	{

        //testing collisions
        if (coll.gameObject.tag == "Bullet")
        {
            Debug.Log("enemy hit with the bullet");
        }
        //if collided with the player it will start
		if(coll.gameObject.tag == "Player")
		{
            // starting the function called startAttackCounter and transforming the collider information out of the onTrigger function
            playerCollider = coll;
			StartAttackCounter();
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
        //reseting the collider information
        playerCollider = null;
	}

    //function called DoAttack
	void DoAttack()
	{		
        // if the player is still collided with the object and its tag is player
		if(playerCollider && playerCollider.gameObject.tag == "Player")
		{
            //if the shield is not activated
            if (!attackingSystem.shield)
			{
                Debug.Log("hit");
                //take damage away from teh player's health
                health_stamina.currentHealth -= damage;
			}
			else
			{
                //take damage away from teh shield
                health_stamina.currentShield -= damage;
			}
            //start teh function attackCounter
			StartAttackCounter();
		}
		else
		{
            //Testing
			Debug.Log("the target escaped");		
		}
	}

    //the function called StartAttackCounter
	void StartAttackCounter()
	{
        //if the player is still collided with the gameObject
        if (playerCollider)
		{
			Debug.Log("start attack");
            //will start teh function DoAttack in 2 seconds
			Invoke("DoAttack", 2);
		}		
	}
}
