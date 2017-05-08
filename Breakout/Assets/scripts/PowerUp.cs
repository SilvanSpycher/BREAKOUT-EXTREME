using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private Rigidbody rigidBody;
    private Collider collider;
    private int power;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
        rigidBody.AddForce(Vector3.down, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Paddle")
        {
            GameManager.instance.PowerActivate(power);
            Destroy(gameObject);
        }

    }
}
