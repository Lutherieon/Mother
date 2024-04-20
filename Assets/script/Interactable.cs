using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{

    public UnityEvent onInterection;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Interact()
    {

        onInterection.Invoke();

    }
}
