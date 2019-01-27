using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{

    private AudioSource source;
    public AudioClip musicClip;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    // Use this for initialization
    void Start()
    {
        play();
    }
   

    public void play()
    {
        source.PlayOneShot(musicClip, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
            play();
    }

}
