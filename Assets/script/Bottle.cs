using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{

    ObjectGrabbable objectGrabbable;
    bool Holding;

    private void Awake()
    {
        objectGrabbable = GetComponent<ObjectGrabbable>();
    }

    void Start()
    {
        ObjectGrabbable.isGrabbed = Holding;
    }

    void Update()
    {
       
    }





    public void Putting()
    {

        if (Holding == true && Input.GetKeyDown(KeyCode.F))
        {
            objectGrabbable.objectGrabPointTransform.position = gameObject.transform.position;

        }
    }
}
