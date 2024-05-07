using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VHS
{
    public class InteractableBase : MonoBehaviour, Iinteractable
    {
        #region Variables

         [Header("Interactable Settings")]

         public float holdDuration;
         [Space]
         public bool holdInteraction;

         public bool multipleUse;

         public bool isInteract;

        #endregion
        #region
         public float HoldDuration => holdDuration;

         public bool HoldInteraction => holdInteraction;

         public bool MultipleUse => multipleUse;

         public bool IsInteract => isInteract;

        #endregion

        #region Methods
         public virtual void OnInteract()
         {
            Debug.Log("interacted" + gameObject.name);
         }



        #endregion





    }

}
