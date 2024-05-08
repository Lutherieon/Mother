using System.Collections;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    [SerializeField] private DialogueSystem DialogueSystem;
    private bool coroutineRunning = false;
    private Coroutine coroutine;
    void Start()
    {
        if (DialogueSystem == null)
        {
            DialogueSystem.GetComponent<DialogueSystem>();
        }
    }

    void Update()
    {
        if(!DialogueSystem.isDialogue)
        transform.Translate(new Vector3(0, 0.1f, 0));


        if(!DialogueSystem.isDialogue && !coroutineRunning)
        {
            coroutine = StartCoroutine(CarMoveOrder());
            coroutineRunning = true;
        }
        else if (DialogueSystem.isDialogue && coroutineRunning)
        {
            StopCoroutine(coroutine);
            coroutineRunning = false;
        }

    }

    IEnumerator CarMoveOrder()
    {
        yield return new WaitForSeconds(1.3f);

        Quaternion startRotation = Quaternion.Euler(-90, 0, -90);
        Quaternion endRotation = Quaternion.Euler(-90, 90, -90);

        float duration = 5.0f;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration; 
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            elapsed += Time.deltaTime; 
            yield return null; 
        }

        transform.rotation = endRotation;
    }
}