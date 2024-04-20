using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iinteractable 
{
    public string InteractionPrompt { get; }

    public bool Interact(Interactor ýnteractor);
}
