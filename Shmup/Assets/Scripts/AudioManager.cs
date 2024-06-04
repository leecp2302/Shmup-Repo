using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioClip[] enemyAudioClips = new AudioClip[1];
    public AudioSource enemyAudioSource;
    private AudioClip engineAudioClip;
    public AudioSource engineAudioSource;
    private AudioClip[] playerAudioClips = new AudioClip[1];
    public AudioSource playerAudioSource;
    private AudioClip[] projectileAudioClips = new AudioClip[1];
    public AudioSource projectileAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        enemyAudioClips[0] = Resources.Load<AudioClip>("Audio/impactMetal_000");
        engineAudioClip = Resources.Load<AudioClip>("Audio/spaceEngineSmall_001");
        engineAudioSource.clip = engineAudioClip;
        engineAudioSource.Play();
        playerAudioClips[0] = Resources.Load<AudioClip>("Audio/laserLarge_000");
        projectileAudioClips[0] = Resources.Load<AudioClip>("Audio/impactMetal_003");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyImpactAudio()
    {
        enemyAudioSource.clip = enemyAudioClips[0];
        enemyAudioSource.Play();
    }

    public void ProjectileImpactAudio()
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
