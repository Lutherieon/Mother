using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    public static bool isGrabbed;
    private Rigidbody rb;
    public Transform objectGrabPointTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isGrabbed = false;
    }
    public void Grab(Transform ObjectGrabPointTransform)
    {

        this.objectGrabPointTransform = ObjectGrabPointTransform;
        isGrabbed=true;
        rb.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        isGrabbed = false;
        rb.useGravity = true;


    }

    private void FixedUpdate()
    {
        if(objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, lerpSpeed * Time.deltaTime);
            rb.MovePosition(newPosition);
            rb.velocity = Vector3.zero;
        }
    }
}
