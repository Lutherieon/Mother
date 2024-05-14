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
    public AudioClip DialogueSFX;

    private void Start()
    {
        // buraya background gelecek.

    }



    public void PlaySFX(AudioClip audioClip)
    {

        SFXSource.PlayOneShot(audioClip);
    }


}
