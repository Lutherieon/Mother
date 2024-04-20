using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Putting : MonoBehaviour
{
    private bool objectGrab; 
    ObjectGrabbable objectGrabbable;
    public Transform PutAreaPosition;



    private void Awake()
    {
        objectGrabbable = GetComponent<ObjectGrabbable>();  
    }
    void Start()
    {
    
        
    }

    void Update()
    {
        objectGrab = ObjectGrabbable.isGrabbed;
        Debug.Log(objectGrab);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && objectGrab && collision.gameObject.tag == "objectBank")
        {
            Debug.Log("f working");

            objectGrabbable.objectGrabPointTransform = PutAreaPosition;


        }
        
    }
}
