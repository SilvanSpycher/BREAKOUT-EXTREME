using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        this.GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void wake()
    {
        this.GetComponent<Renderer>().enabled = true;
        rigidBody.AddForce(Vector3.down, ForceMode.Impulse);
    }
}
