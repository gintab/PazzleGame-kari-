using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void Change()
    {
        Debug.Log("a");
        SceneManager.LoadScene("Stage"+(StageManager.Instance.NowScene+1));
    }
}
