using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public int Strength
    {
        get; set;
    }


	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void OnHit()
    {
        Strength -= 1;
        if (Strength <= 0)
        {
            GameManager.instance.BlockDestroyed(transform.position);
            Destroy(gameObject);
        }
    }

}
