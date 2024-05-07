//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using VHS;

//public class PickingController : MonoBehaviour
//{


//    [SerializeField] private Transform playerCameraTransform;
//    [SerializeField] private Transform objectGrabPointTransform;
//    [SerializeField] private LayerMask pickUpLayerMask;
//    private PickableObject pickableObject;
//    InteractableBase interactableBase;
//    public static bool canDrop;

//    private void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            if (pickableObject == null)
//            {
//                // Not carrying an object, try to grab
//                float pickUpDistance = 4f;
//                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
//                {
//                    if (raycastHit.transform.TryGetComponent(out pickableObject))
//                    {
//                        pickableObject.PickUp(objectGrabPointTransform);
//                    }
//                }
//            }
//            else
//            {
//                if(canDrop == true)
//                {
//                    pickableObject.Drop();
//                    pickableObject = null;
//                }
//                // Currently carrying something, drop
//            }
//        }
//    }
//}