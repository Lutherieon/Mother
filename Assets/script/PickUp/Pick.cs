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
    [SerializeField] Transform ObjectGrapPointTransform;

    private ObjectGrabbable objectGrabbable;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null) 
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, PickUpDistance, pickableObjectLayer))
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

        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * PickUpDistance, Color.red);
    }
}
