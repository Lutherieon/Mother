using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private Text dialogueText;
    [SerializeField] private string[] sentenceOrder;
    [SerializeField] private float writingSpeed;
    [SerializeField] private GameObject dialogueCanvas;
    private int index;

    private void Start()
    {
        dialogueText.text = string.Empty;
        if (dialogueCanvas != null)
            dialogueCanvas.SetActive(false); // Hide the dialogue canvas initially
        StartDialogue();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSentence();
        }
    }

    public void StartDialogue()
    {
        index = 0;
        dialogueText.text = string.Empty;
        StartCoroutine(WritingOrder());
    }

    IEnumerator WritingOrder()
    {
        foreach (char letter in sentenceOrder[index].ToCharArray())
        {
            dialogueText.text += letter;
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
                dialogueCanvas.SetActive(false); // Close the dialogue canvas
        }
    }
}