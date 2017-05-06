using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Vector3 direction = Vector3.zero;
    private float speed = 1f;
    private Collider collider;
    private Rigidbody rigidBody;
    private float constantSpeed = 5f;
    // Use this for initialization
    void Start()
    {
        direction.x = 2;//Random.Range(-10f, 1f);
        direction.y = 1;// Random.Range(-1f, 10f);
        collider = GetComponent<Collider>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(direction, ForceMode.Impulse);
    }

    void LateUpdate()
    {
        rigidBody.velocity = constantSpeed * (rigidBody.velocity.normalized);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            GameManager.instance.Delete(collision.gameObject);
        }
        else if (collision.gameObject.tag == "PowerUp")
        {
            Physics.IgnoreCollision(collision.collider, collider);
        }
    }

}
