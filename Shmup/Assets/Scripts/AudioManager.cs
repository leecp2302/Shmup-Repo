using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playerAudioClips = new AudioClip [1];
    private AudioSource playerAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerAudioClips[0] = Resources.Load<AudioClip>("laserLarge_000");
        playerAudioSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaserAudio()
    {
        playerAudioSource.clip = playerAudioClips[0];
        playerAudioSource.Play();
    }
}
