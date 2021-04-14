using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalObj : Block
{
    GameObject canvas = null;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
    }
    public override void Hit()
    {
        Instantiate(Resources.Load("ClearPanel"), canvas.transform);
    }
}
