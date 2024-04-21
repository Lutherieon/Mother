using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    [Header("RayCast")]
    RaycastHit hit;
    [SerializeField] float PickUpDistance;
    [SerializeField] Transform playerCameraTransform;
    [SerializeField] LayerMask pickableObjectLayer;
    [SerializeField] public Transform ObjectGrapPointTransform;


    


    private ObjectGrabbable objectGrabbable;

    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) )
        {
            if (objectGrabbable == null) 
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, PickUpDistance, pickableObjectLayer) )
                {
                    if (hit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(ObjectGrapPointTransform);

                    }

                }
            }

            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
                
            }
            

        }

    }
}