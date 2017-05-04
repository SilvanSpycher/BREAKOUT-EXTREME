using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Vector3 direction = Vector3.zero;
    private float speed = 0.2f;


	// Use this for initialization
	void Start () {
        direction.x = Random.Range(-1f, 1f);
        direction.y = Random.Range(-1f, 1f);


	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "paddle")
        {
            rigidBody.AddForce(new Vector2(-50, 20), ForceMode.Impulse);
            rigidBody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);


        }
        else if ( collision.gameObject.tag == "block")
        {



        }
    }

    private void Update()
    {
        
       
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(direction * speed);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0 || pos.x > 1)
        {
            pos.x = Mathf.Clamp01(pos.x);
            bounce("x");
        }
        
        if (pos.y > 1)
        {
            pos.y = Mathf.Clamp01(pos.y);
            bounce("y");
        }

        
        
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }


    private void bounce(string axe)
    {


    }
}
