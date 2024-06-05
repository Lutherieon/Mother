using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;
public class Radio : InteractableBase
{
    [SerializeField]Animator animator;
    [SerializeField] AudioManager audioManager;



    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();   
    }
    public override void OnInteract()
    {
        base.OnInteract();
        animator.SetBool("RadioFell", true);
    }


    void PlayMusic()
    {
        audioManager.PlaySFX(audioManager.radio);

    }

}
