using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {


    // creating variables to be accessed from teh Inspector
    public float health;
    public GameObject[] loot;
    int randomNumber;

    //will start every frame 
    void Update ()
    {
        //an if statement to start when the gameObject's health equals to 0
        if (health <= 0)
        {
            //will generate a rendom number between 0 and 5
            randomNumber = Random.Range(0, 5);
            // will spawn a random clone of the gameObject from the array called loot in the same position and rotation as the attached gameObject
            Instantiate(loot[randomNumber], this.gameObject.transform.position, this.gameObject.transform.rotation);
            // destroys the object the script is attached to
            Destroy(this.gameObject);
        }
	}
}
