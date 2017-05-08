using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;
    private float powerUpChance = 0f;
    [SerializeField] private float chanceIncrease;
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject block;

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

    public void DeleteBall(Ball ball)
    {
        Destroy(ball.gameObject);
    }

    public void TouchBlock(Block block)
    {
        block.OnHit();
    }

    public void BlockDestroyed(Vector3 blockposition)
    {
        powerUpChance += chanceIncrease;
        if(Random.Range(0f, 1f) < powerUpChance)
        {
            GameObject newPowerUp = Instantiate(powerUp) as GameObject;
            newPowerUp.transform.position = blockposition;
            powerUpChance = 0;
        }
    }
    
    public void PowerActivate(string power)
    {

    }
}
