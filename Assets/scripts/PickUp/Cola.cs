using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using VHS;

public class Cola  : InteractableBase  
{
    [SerializeField] FriendManager friendManager;
    [SerializeField] private Volume volume;
    [SerializeField] private VolumeProfile profile;
    [SerializeField] AudioManager audioManager;
    [SerializeField] CharacterMovement characterMovement;
    private bool jump;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    private void Start()
    {
        
    }

    public override void OnInteract()
    {
        base.OnInteract();
        characterMovement.jumpSpeed += 5f;
        audioManager.PlaySFX(audioManager.CokeOpeningSound);
        Destroy(gameObject);
        ScoreManager.score += 50;
        


       
    }




}
