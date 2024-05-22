using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------Audio Source------")]
    [SerializeField] AudioSource MusicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------Audio Clip------")]
    public AudioClip backgroundMusic;
    public AudioClip endLevel;
    public AudioClip CarSound;
    public AudioClip ElectMicroWave;
    public AudioClip ElectSocket;
    public AudioClip DialogueSFX;
    public AudioClip FootStep;
    public AudioClip FireBigSound;

    private void Start()
    {
        // buraya background gelecek.

    }



    public void PlaySFX(AudioClip audioClip)
    {

        SFXSource.PlayOneShot(audioClip);
    }


    public void StopSFX()
    {
        SFXSource.Stop();
    }


}
