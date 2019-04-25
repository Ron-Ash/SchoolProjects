using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerSystemPrototype : MonoBehaviour {

    // variables to be accessed and manipulated in the Inspector
    public GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float shift;
    Vector3 mousePosition;
    Camera mainCamera;
    PlayerMobility playerMobility;
    float zValue = 0.0f;
    float mod = 0.05f;

    void Start()
    {
        //connects the script to the player, its playermobility script and the main camera
        //player = GameObject.FindGameObjectWithTag("Player");
        playerMobility = player.GetComponent<PlayerMobility>();
        mainCamera = GetComponent<Camera>();
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        // starts the function called cameraeffect
        //cameraEffects();

        // an if statement that will start if the key shift is pressed
        if(Input.GetKey(KeyCode.LeftShift))
        {
            //changes the camera's field of view to the variable shift's size
            mainCamera.orthographicSize = shift;
            //sets the player mobility to false disabling its movement
            playerMobility.setMoving(false);
            // starts the function called lookAhead
            lookAhead();
        }
        else
        {
            //returns the camera's field of view to normal
            mainCamera.orthographicSize = 2.0f;
            //starts the function followPlayer
            followPlayer();
        }  
    }

    void followPlayer()
    {
        // changes teh camera's position to be fixed to the player
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }

    void lookAhead()
    {
        //changes the camera's position to follow teh mouse
        Vector3 cameraPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        Vector3 direction = cameraPosition-this.transform.position;
        transform.Translate(direction * 1 * Time.deltaTime);
    }

    
}
