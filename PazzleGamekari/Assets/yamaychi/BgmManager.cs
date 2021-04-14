using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    AudioSource audioSource = null;
    [SerializeField] AudioClip BGM = null;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        PlayBGM();
    }
    public void PlayBGM()
    {
        audioSource.PlayOneShot(BGM);
    }

}
