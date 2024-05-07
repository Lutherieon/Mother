using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VHS
{

    [CreateAssetMenu(fileName = "InteractionInputData", menuName = "InteractionSystem/InputData")]

    public class InteractionInputData : ScriptableObject
    {
        public bool m_interactedClicked;

        public bool m_interactedRelease;

        public bool InteractedClicked
        {
            get => m_interactedClicked;
            set => m_interactedClicked = value;
        }

        public bool InteractedRelease
        {
            get => m_interactedRelease;
            set => m_interactedRelease = value;
        }

        public void ResetInput()
        {
            m_interactedClicked = false; m_interactedRelease = false;
        }

    }

}




