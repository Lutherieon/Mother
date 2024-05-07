using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VHS
{
    [CreateAssetMenu(fileName = "Interaction Data", menuName = "InteractionSystem/InteractionData")]
    public class InteractionData : ScriptableObject
    {
        private InteractableBase m_interactableBase;
        public InteractableBase Interactable { get => m_interactableBase; set => m_interactableBase = value; }

        public void Interact()
        {
            m_interactableBase.OnInteract();
            ResetData();
        }

        public bool IsSameInteractable(InteractableBase _newInteractable)
        {
            return m_interactableBase == _newInteractable;
        }
        public bool IsEmpty() => m_interactableBase == null;
        

        public void ResetData()
        {
            m_interactableBase = null;
        }

        
        
    }

}
