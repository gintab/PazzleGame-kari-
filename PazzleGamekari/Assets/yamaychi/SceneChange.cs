using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void Change()
    {
        Debug.Log("a");
        SceneManager.LoadScene((StageManager.Instance.NowScene + 1)+"Stage");
    }
}
