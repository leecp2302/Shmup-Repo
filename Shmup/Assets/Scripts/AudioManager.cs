using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioClip[] playerAudioClips = new AudioClip[1];
    public AudioSource playerAudioSource;
    private AudioClip[] projectileAudioClips = new AudioClip[1];
    public AudioSource projectileAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerAudioClips[0] = Resources.Load<AudioClip>("laserLarge_000");
        projectileAudioClips[0] = Resources.Load<AudioClip>("impactMetal_003");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImpactAudio()
    {
        projectileAudioSource.clip = projectileAudioClips[0];
        projectileAudioSource.Play();
    }

    public void LaserAudio()
    {
        playerAudioSource.clip = playerAudioClips[0];
        playerAudioSource.Play();
    }
}
