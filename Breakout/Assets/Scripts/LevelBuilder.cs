using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{

    [SerializeField] private GameObject block;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {

    }

    public bool BuildLevel(int levelnumber)
    {
        for (int i = 1; i < 6; i++)
        {
            for (int j = -10; j < 10; j += 2)
            {
                GameObject newblock = Instantiate(block) as GameObject;
                newblock.transform.position = new Vector3(j, i, 0);

            }
        }


        return true;
    }





}