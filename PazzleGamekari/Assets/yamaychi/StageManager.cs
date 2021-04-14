using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    public int NowScene { private set; get; } = 0;
    private void Start()
    {
        NowScene = 1;
    }

}
