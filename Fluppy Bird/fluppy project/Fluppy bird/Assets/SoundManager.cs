using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] clips;
    AudioSource audiosource;
    public static SoundManager singleton;

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        singleton = this;
    }
    
    public void Playsound (int clipIndex)
    {
        audiosource.PlayOneShot(clips[clipIndex]);
    }
}
