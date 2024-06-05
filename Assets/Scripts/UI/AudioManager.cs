using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source...............")]
    public AudioSource Music;
    public AudioSource VFX;
    [Header("VFX......................")]
    public AudioClip _startBGM;
    public AudioClip _waitingBGM;
    public AudioClip _gunShoot;    
    public AudioClip _playerDied;
    public AudioClip _killEnemy;
    public AudioClip _takeDamage;

    bool Option = false;

    private void Start()
    {
        Music.clip = _startBGM;
        Music.Play();
    }
    public void PlayVFX(AudioClip clip)
    {
        VFX.PlayOneShot(clip);
    }
}
