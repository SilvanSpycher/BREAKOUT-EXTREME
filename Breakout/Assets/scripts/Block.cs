using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {



    private MeshRenderer meshrenderer;


    public int Strength
    {
        get; set;
    }



	// Use this for initialization
	void Start ()
    {
        meshrenderer = GetComponent<MeshRenderer>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnHit()
    {
        Strength -= 1;
        ColorUpdate();
        if (Strength <= 0)
        {
            GameManager.instance.BlockDestroyed(transform.position);
            Destroy(gameObject);
        }
    }

    public void ColorUpdate()
    {
        Color color = meshrenderer.material.color;
        switch (Strength)
        {
            case 1:
                color.a = 0.5f;
                break;

            case 2:
                color.a = 0.6f;
                break;

            case 3:
                color.a = 0.7f;
                break;

            case 4:
                color.a = 0.8f;
                break;

            default:
                color.a = 0.9f;
                break;
        }
        meshrenderer.material.color = color;
    }

}
