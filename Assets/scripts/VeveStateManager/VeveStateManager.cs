using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeveStateManager : MonoBehaviour
{
    [Header (" Access ")]
    [SerializeField] private DialogueSystem _dialogueSystem;

    [Header (" Image ")]     
    [SerializeField] private GameObject veve;
    void Start()
    {
        
    }

    void Update()
    {
        if (_dialogueSystem.isDialogue == true)
        {
            veve.SetActive (false);
        }
        else 
        {
            veve.SetActive (true); 
        }
    }
}
