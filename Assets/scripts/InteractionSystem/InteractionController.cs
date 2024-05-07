using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VHS
{
    public class InteractionController : MonoBehaviour
    {
        #region Variable
        [Header("Data")]
        public InteractionInputData InteractionInputData;

        public InteractionData InteractionData;

        [SerializeField] private InteractionUIPanel uIPanel;

        [Space]
        [Header("Ray Settings")]
        public float rayDistance;

        public float raySphereRadius;

        public LayerMask interactableLayer;

        private Camera m_camera;

        private bool m_interacting;
        private float m_holdTimer = 0f;
        #endregion



        #region BuildInMethods
        private void Awake()
        {
            m_camera = Camera.main;
        }


        private void Update()
        {
            CheckForInteractable();
            CheckForInteractableInput();
        }

        #endregion


        #region

        

        private void CheckForInteractable()
        {
            Ray ray = new Ray(m_camera.transform.position, m_camera.transform.forward);
            RaycastHit _hitInfo;

            bool _hitSomething = Physics.SphereCast(ray, raySphereRadius,out _hitInfo ,rayDistance, interactableLayer, QueryTriggerInteraction.UseGlobal);

            if (_hitSomething)
            {
                //checking the object has Interactable base or not 
                InteractableBase _InteractableBase = _hitInfo.transform.GetComponent<InteractableBase>();
                if (_InteractableBase != null)
                {
                    if(InteractionData.IsEmpty())
                    {
                        // interactionda her zaman droplamaz.
                        //PickingController.canDrop = false;
                        InteractionData.Interactable = _InteractableBase;
                    }
                    else
                    {
                        if (!InteractionData.IsSameInteractable(_InteractableBase))
                        {
                            //PickingController.canDrop = false;
                            InteractionData.Interactable = _InteractableBase;

                        }


                    }
                }
            }
            else
            {
                // we do something else 
                InteractionData.ResetData();
                uIPanel.Reset();
            }


            Debug.DrawRay(ray.origin, ray.direction * rayDistance, _hitSomething ? Color.green : Color.red);
        }
        private void CheckForInteractableInput()
        {
            if (InteractionData.IsEmpty())
            {
                return;
            }
            if(InteractionInputData.InteractedClicked)
            {
                m_interacting = true;
                m_holdTimer = 0f;

            }


            if (InteractionInputData.InteractedRelease)
            {
                m_interacting = false;
                m_holdTimer = 0f;
                uIPanel.UpdateProgressBar(0f);

            }

            if (m_interacting)
            {
                if (!InteractionData.Interactable.isInteract)
                {
                    return ;
                }
                if (InteractionData.Interactable.holdInteraction)
                {
                    m_holdTimer += Time.deltaTime;
                    float heldPercet = m_holdTimer / InteractionData.Interactable.holdDuration;
                    uIPanel.UpdateProgressBar(heldPercet);
                    if (heldPercet > 1f)
                    {
                        InteractionData.Interact();
                        m_interacting =false;
                    }

                }
                else 
                {
                    InteractionData.Interact();
                    m_interacting=false;
                }

            }
        }

        #endregion

    }

}
