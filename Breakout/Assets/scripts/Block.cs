using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] private PowerUp powerUp;


    public int Strength
    {
        get; set;
    }


	// Use this for initialization
	void Start () {
        if (powerUp != null)
        {
            powerUp.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPowerUp(PowerUp newPowerUp)
    {
        powerUp = newPowerUp;
    }

    public void OnHit()
    {
        Strength -= 1;
        if (Strength <= 0)
        {
            GameManager.instance.BlockDestroyed(this.transform.position);
            Destroy(this.gameObject);
        }
    }


    public void OnDestroy()
    {
        if (powerUp != null)
        {
            powerUp.gameObject.SetActive(true);
        }
    }
}
