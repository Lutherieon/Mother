using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody rb;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    public void Grab(Transform ObjectGrabPointTransform)
    {
        this.objectGrabPointTransform = ObjectGrabPointTransform;
        rb.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        rb.useGravity = true;


    }

    private void FixedUpdate()
    {
        if(objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, lerpSpeed * Time.deltaTime);
            rb.MovePosition(newPosition);
        }
    }
}
