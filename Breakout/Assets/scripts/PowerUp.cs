using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private Rigidbody rigidBody;
    private Renderer renderer;
    private Collider collider;
    // Use this for initialization
    void Start () {

        this.renderer = GetComponent<Renderer>();
        this.rigidBody = GetComponent<Rigidbody>();
        this.collider = GetComponent<Collider>();
        renderer.enabled = false;
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Paddle")
        {
            GameManager.instance.DeletePowerUp(this);
        }

        else if (collision.gameObject.tag == "Block")
        {
            Physics.IgnoreCollision(collision.collider, collider);
        }
        else if (collision.gameObject.tag == "Ball")
        {
            Physics.IgnoreCollision(collision.collider, collider);
        }
    }

    public void Wake()
    {
        renderer.enabled = true;
        rigidBody.AddForce(Vector3.down, ForceMode.Impulse);
    }
}
