using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    //[SerializeField] private string _promt;
    //public string InteractionPrompt  => _promt;
    //public bool Interact(Interactor Interactor)
    //{
    //    Debug.Log("opened");

    //    return true;
    //}







    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("hello");
            transform.rotation = Quaternion.Euler(0f, 120f, 0f);

        }
    }

}
