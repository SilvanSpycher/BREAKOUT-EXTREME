using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Vector3 direction = Vector3.zero;
    private float speed = 0.2f;
    private Collider collider;
    private Rigidbody rigidBody;

    // Use this for initialization
    void Start () {
        direction.x = Random.Range(-1f, 1f);
        direction.y = Random.Range(-1f, 1f);
        collider = GetComponent<Collider>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Paddle")
        {
            Bounce("y");
        }
        else if (collision.gameObject.tag == "Block")
        {
            if (DecideBounceX(transform.position - collision.transform.position))
            {
                Bounce("x");
            }
            else
            {
                Bounce("y");
            }

            GameManager.instance.Delete(collision.gameObject);
        }
        else if (collision.gameObject.tag == "PowerUp")
        {
            Physics.IgnoreCollision(collision.collider, collider);
        }
    }

    private bool DecideBounceX(Vector3 distance)
    {
        if (Mathf.Abs(distance.y) > (0.525)) //0.525 = ball.width/2 + block.width/2
        {
            //if (Mathf.Abs(distance.x) > (0.525)){   }         //this would be the case of the ball hitting exactly the edge

            return false;
        }
        else
        {
            return true;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        transform.Translate(direction * speed);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0 || pos.x > 1)
        {
            pos.x = Mathf.Clamp01(pos.x);
            Bounce("x");
        }
        
        if (pos.y > 1)
        {
            pos.y = Mathf.Clamp01(pos.y);
            Bounce("y");
        }

        if (pos.y < 0)
        {
            GameManager.instance.DeleteBall(this);
        }

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }


    private void Bounce(string axis)
    {
        if (axis == "x")
        {
            direction.x = -direction.x;
        }

        if (axis == "y")
        {
            direction.y = -direction.y;
        }

    }
}
