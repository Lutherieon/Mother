using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VHS
{
    
    public class mug : InteractableBase
    {
        [SerializeField] Animator animator;

        [SerializeField] AudioManager audioManager;



        private void Awake()
        {
            audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }
        public override void OnInteract()
        {
            base.OnInteract();
            animator.SetBool("CanMove", true);
        }


        void PlayMusic()
        {
            audioManager.PlaySFX(audioManager.GlassShadering);

        }
    }

}
