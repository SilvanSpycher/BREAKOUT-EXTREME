using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class LevelBuilder : MonoBehaviour
{

    [SerializeField] private GameObject block;
    private int line;
    private int row;
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
        line = 0;
        row = 0;
        TextAsset file = Resources.Load("Levels/" + levelnumber) as TextAsset;
        // Handle any problems that might arise when reading the text
        string[] linesFromfile = file.text.Split("\n"[0]);

        for (int i = 7; i >= -2; i--)
        {
            string currentline = linesFromfile[line];


            for (int j = -12; j <= 12; j += 2)
            {
                int strength = (int)currentline[row] - '0';
                if (strength > 0)
                {
                    GameObject newblock = Instantiate(block) as GameObject;

                    newblock.transform.position = new Vector3(j, i, 0);
                    newblock.GetComponent<Block>().Strength = strength;
                }
                

                row += 1;
            }


            line += 1;
            row = 0;

        }


        return true;
    }

    private void Parser(string[] entries)
    {

    }

}