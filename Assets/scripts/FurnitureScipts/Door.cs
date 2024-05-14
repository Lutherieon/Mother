using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VHS
{

    public class Door : InteractableBase
    {

        [SerializeField] Animator animator;
        bool isOpened;
        private void Awake()
        {
            animator = GetComponent<Animator>();    
        }


        private void Start()
        {
            animator.SetBool("doorOpen", false);

        }

        public override void OnInteract()
        {
            base.OnInteract();
            if (!isOpened) 
            {
                animator.SetBool("doorOpen", true);
                isOpened = true;
            }

            else if (isOpened)
            {
                animator.SetBool("doorOpen", false);
                isOpened = false;
            }



        }
    }

}
