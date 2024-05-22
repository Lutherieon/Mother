using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("Dialogue Logic")]
    [SerializeField] private Text dialogueText;
    [SerializeField] private string[] sentenceOrder;
    [SerializeField] private float writingSpeed;
    [SerializeField] public bool isDialogue;
    private int index;

    [Header("Dialogue Image Logic")]
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private GameObject DialogueImageMother;
    [SerializeField] private GameObject DialogueImageEviLVeve;
    [Header("Player Eneble")]
    [SerializeField] private Transform Player;
    [SerializeField] private CharacterController characterController;

    [Header("Audio")]
    [SerializeField] AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void Start()
    {
        dialogueText.text = string.Empty;
        if (dialogueCanvas != null)
            dialogueCanvas.SetActive(true); // Hide the dialogue canvas initially
        isDialogue = true;
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
        if (index == 3f) 
        {
            //change the images for dialogue system for the bad veve
            DialogueImageMother.SetActive(false);
        }
        else if (index == 4f)
        {
            DialogueImageEviLVeve.SetActive(true);

        }

        Debug.Log(isDialogue);
    }

    public void StartDialogue()
    {
        index = 0;
        dialogueText.text = string.Empty;
        if(Player.TryGetComponent(out characterController))
        {
            characterController.enabled = false;
        }
        StartCoroutine(WritingOrder());
    }

    IEnumerator WritingOrder()
    {
        foreach (char letter in sentenceOrder[index].ToCharArray())
        {
            dialogueText.text += letter;
            audioManager.PlaySFX(audioManager.DialogueSFX);
            yield return new WaitForSeconds(writingSpeed);
        }
    }

    public void ResetSentence()
    {
        dialogueText.text = string.Empty;
    }

    public void NextSentence()
    {
        if (index < sentenceOrder.Length - 1)
        {
            index++;
            StopAllCoroutines(); // Stop any currently running coroutine
            dialogueText.text = string.Empty;
            StartCoroutine(WritingOrder());
        }
        else
        {
            // End of dialogue
            dialogueText.text = string.Empty;
            
            if (dialogueCanvas != null)
            {
                dialogueCanvas.SetActive(false); // Close the dialogue canvas
            }
            isDialogue = false;
            StopAllCoroutines();
            characterController.enabled = true;
            //audioManager.StopSFX(); // bug yapiyordu oyundaki tum sesleri kapatiyordu.

        }
    }
}