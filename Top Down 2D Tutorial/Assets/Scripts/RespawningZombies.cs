using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningZombies : MonoBehaviour {

    //gameObjects taht will be able to be accessed from teh Inspectro
    public GameObject portals;
    public GameObject zombies;
    bool spawning;
    float canSpawnNow = 5;

    // setting the spawning variable to true
    void Start()
    {
        spawning = true;
    }
	
	// Update is called once per frame
	void Update () {
        // this function will spawn a zombie every time spawning is true
		if(spawning == true)
        {
            //sets spawning to false
            spawning = false;
            //spawns a zombie clone of the prefab "Enemy" in the portal's location and it's rotation
            Instantiate(zombies, portals.transform.position, portals.transform.rotation);
            //starts the void startSpawning in the amount specified in teh variable canSpawnNow (5)
            Invoke("StartSpawn", canSpawnNow);
        }
	}

    //created a void called startspawn
    void StartSpawn()
    {
        //sets spawning to true in order for the program to create another zombie clone
        spawning = true;
    }
}
