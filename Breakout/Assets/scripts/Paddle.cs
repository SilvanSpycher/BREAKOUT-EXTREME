using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    private Rigidbody rigidBody;
    private int moveDirection = 0;
    private float speed = 0.25f;
    

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
        
        
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width/2)
            {
                moveLeft();
            }
            else if (Input.mousePosition.x < Screen.width / 2)
            {
                moveRight();
            }
        }
	}


    void moveLeft()
    {
        moveDirection = 1;
    }

    void moveRight()
    {
        moveDirection = -1;
    }

    private void FixedUpdate()
    {
       
        transform.Translate(Vector3.right * moveDirection * speed);
        moveDirection = 0;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
