using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    public float speed;
    public GameObject firePosition;

	void Awake()
    {
        Invoke("Destroy", 0.5f);
	}   

    void FixedUpdate()
    {
        transform.Translate(transform.position.x * speed, transform.position.y, transform.position.z);
    }

    void Destroy()
    {
        Debug.Log("the bullet has been destroyred");
        Destroy(gameObject);
    }
}
