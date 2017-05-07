using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

    [SerializeField] private GameObject block;
    public static LevelBuilder instance = null;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

    public bool BuildLevel (int levelnumber)
    {
        for (int i=1; i<6; i++)
        {
            for (int j=-10; j<10; j+=2)
            {
                print("hello");
                GameObject newBlock = Instantiate(block) as GameObject;
                newBlock.transform.position = new Vector3( j, i, 0);
                
            }
        }


        return true;
    }





}
