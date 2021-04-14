using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    // Start is called before the first frame update
    AudioSource audioSource = null;
    [SerializeField] AudioClip Suberi = null;
    [SerializeField] AudioClip Stop = null;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void SubeSE()
    {
        audioSource.PlayOneShot(Suberi);
    }
    public void StopSE()
    {
        audioSource.PlayOneShot(Stop);
    }
}
