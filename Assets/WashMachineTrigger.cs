using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashMachineTrigger : MonoBehaviour
{
    PickUpObject pickUpObject;
    [SerializeField] GameObject washMachine;
    private void Awake()
    {
        pickUpObject = GetComponent<PickUpObject>();
    }
    bool inputBool;
    void Start()
    {
        inputBool = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            inputBool = true;

        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && inputBool)
        {
            Debug.Log("marga");
            pickUpObject.ObjectGrapPointTransform.transform.position = washMachine.transform.position;


        }
    }
}
