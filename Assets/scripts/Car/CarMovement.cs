using System.Collections;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    [SerializeField] private DialogueSystem DialogueSystem;
    private bool coroutineRunning = false;
    private Coroutine coroutine;
    public Animator car_drift;
  
    void Start()
    {
        if (DialogueSystem == null)
        {
            DialogueSystem.GetComponent<DialogueSystem>();
        }
    }
    private void Update()
    {
        if (!DialogueSystem.isDialogue)
        {
            car_drift.SetBool("CarAnimBool", true);
           
        }
        else { return; }
    }
}

