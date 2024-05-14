using System.Collections;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    [SerializeField] private DialogueSystem DialogueSystem;
    public Animator car_drift;
    public bool engineStart;

    [SerializeField] AudioManager audioManager;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
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
        else 
        {
            return;


        }
    }

    public void Car_Sfx()
    {
        audioManager.PlaySFX(audioManager.CarSound);
    }

    
}

