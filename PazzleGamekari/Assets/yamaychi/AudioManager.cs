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
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void SubeSE()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(Suberi);
        }
        
    }
    public void StopSE()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(Stop);
        }
    }
}
