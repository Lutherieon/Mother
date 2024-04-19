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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, PickUpDistance, pickableObjectLayer))
            {
                if (hit.transform.TryGetComponent(out ObjectGrabbable objectGrbbable))
                {
                    Debug.Log(objectGrbbable);

                }

            }

        }

        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * PickUpDistance, Color.red);
    }
}
