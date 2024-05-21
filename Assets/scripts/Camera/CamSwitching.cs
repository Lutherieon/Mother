using System.Collections;
using UnityEngine;

public class CamSwitching : MonoBehaviour
{
    [SerializeField] private DialogueSystem diaSystem;
    [SerializeField] private Camera camPlayer;
    [SerializeField] private Camera camTopDown;
    [SerializeField] private float delayAfterDialogue = 2.5f; // Delay in seconds after dialogue ends

    [SerializeField] AudioManager audioManager;
    private bool canPlayBackgroundMusic;


    private bool lastDialogueState;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        // Ensure the DialogueSystem is correctly assigned
        if (diaSystem == null) diaSystem = GetComponent<DialogueSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canPlayBackgroundMusic = false;
        // Initial camera state update based on the dialogue state
        UpdateCameraState(diaSystem.isDialogue);
        lastDialogueState = diaSystem.isDialogue;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the dialogue state has changed
        if (diaSystem.isDialogue != lastDialogueState)
        {
            if (diaSystem.isDialogue)
            {
                // If dialogue has started, switch immediately to the top-down camera
                UpdateCameraState(true);
            }
            else
            {
                // If dialogue has ended, start a delay before switching back to the player camera
                StartCoroutine(DelayedCameraSwitch());


            }
            lastDialogueState = diaSystem.isDialogue;
        }
       
    }

    private IEnumerator DelayedCameraSwitch()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delayAfterDialogue);
        // After the delay, update the camera state back to the player camera
        UpdateCameraState(false);
        yield return new WaitForSeconds(3);

        audioManager.PlaySFX(audioManager.backgroundMusic);


    }

    private void UpdateCameraState(bool isDialogueActive)
    {
        // Toggle cameras based on the dialogue state
        camPlayer.enabled = !isDialogueActive;
        camTopDown.enabled = isDialogueActive;
    }
}
