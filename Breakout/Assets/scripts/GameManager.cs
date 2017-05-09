using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    [SerializeField] private float chanceIncrease;
    [SerializeField] private GameObject powerUp;
    [SerializeField] private GameObject block;
    [SerializeField] private LevelBuilder levelBuilder;

    public static GameManager instance = null;
    private float powerUpChance = 0f;
    private int powerid;

    // Use this for initialization
    void Start ()
    {
        float targetaspect = 16.0f / 10.0f;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // obtain camera component so we can modify its viewport
        Camera camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }


            /* for (int i = 1; i < 6; i++)
             {
                 for (int j = -10; j < 10; j += 2)
                 {
                     GameObject newblock = Instantiate(block) as GameObject;
                     newblock.transform.position = new Vector3(j, i, 0);

                 }
             }*/
            BuildLevel(1);
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
            blockposition.z = -0.5f;
            newPowerUp.transform.position = blockposition;
            newPowerUp.SendMessage("TheStart", powerid);
            powerUpChance = 0;
        }
    }
    
    public void PowerActivate(int power)
    {
        switch (power)
        {
            case 1:         //paddle bigger
                break;
            case 2:         //paddle smaller
                break;
            case 3:         //3 balls
                break;
            case 4:         //ball faster
                break;
            case 5:         //ball slower
                break;
            case 6:         //ball sticks to paddle
                break;
            case 7:         //ball destroys blocks without bouncing
                break;
            case 8:         //ball bigger
                break;
            case 9:         //ball smaller
                break;
            case 10:        //rockets from paddle
                break;
            case 11:        //+1 life
                break;
            case 12:        //bullettime
                break;      

        }
    }

    private void BuildLevel(int levelnumber)
    {
        levelBuilder.BuildLevel(levelnumber);
    }
}
