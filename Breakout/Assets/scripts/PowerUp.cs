using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private Rigidbody rigidBody;
    private int power;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(Vector3.down, ForceMode.Impulse);

    }

    void TheStart(int powerid)
    {
        power = powerid;
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
