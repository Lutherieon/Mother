using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, Iinteractable
{
    [SerializeField] private string _promt;
    public string InteractionPrompt  => _promt;
    public bool Interact(Interactor Interactor)
    {
        Debug.Log("opened");
        
        return true;
    }
    
}
