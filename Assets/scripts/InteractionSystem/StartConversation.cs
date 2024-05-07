using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class StartConversation : InteractableBase
{

    [SerializeField] private Transform dialogueCanvas;
    private DialogueSystem dialogueSystem;
    public override void OnInteract()
    {
        base.OnInteract();
        dialogueCanvas.gameObject.SetActive(true);
        //dialogueSystem.GetComponent<DialogueSystem>().ResetSentence();
    }
}
