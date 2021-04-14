using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBlock : Block
{
    GameObject block1;
    GameObject block2;
    bool block = true;
    // Start is called before the first frame update
    void Start()
    {
        block2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")|| Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d"))
        {
            if (block == true)
            {
                block1.SetActive(false);
                block2.SetActive(true);
                block = false;
            }
            else 
            {
                block1.SetActive(true);
                block2.SetActive(false);
                block = true;
            }
        }
    }

    public override void Hit()
    {

    }
}
