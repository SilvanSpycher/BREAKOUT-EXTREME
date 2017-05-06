using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;


	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {

        }

        DontDestroyOnLoad(gameObject);
    }

    public void Delete(GameObject obj)
    {
        Destroy(obj.gameObject);
    }

    public void DeletePowerUp(PowerUp powerUp)
    {
        Destroy(powerUp.gameObject);
    }

    public void DeleteBall(Ball ball)
    {
        Destroy(ball.gameObject);
    }
    
}
