using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AudioControll : MonoBehaviour
{
    public static AudioControll current;
    private AudioSource audioSource;

    public AudioClip punch;

    public AudioClip pistolFire;
    public AudioClip pistolTransition;

    public AudioClip shotgunTransition;
    public AudioClip shotgunFire;

    public AudioClip explosionBomb;
    public AudioClip birdHit;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
