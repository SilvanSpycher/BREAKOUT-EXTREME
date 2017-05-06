using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] private PowerUp powerUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPowerUp(PowerUp newPowerUp)
    {
        powerUp = newPowerUp;
    }


    public void OnDestroy()
    {
        if (powerUp != null)
        {
            powerUp.wake();
        }
    }
}
