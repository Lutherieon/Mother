using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hnts : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Text text;
    [SerializeField] string writingText;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(hintFirs());
        }
    }



    IEnumerator hintFirs()
    {
        animator.SetBool("Hint", true);
        text.text = writingText;
        yield return new WaitForSeconds(5.0f);
        animator.SetBool("Hint", false);
    }
}
