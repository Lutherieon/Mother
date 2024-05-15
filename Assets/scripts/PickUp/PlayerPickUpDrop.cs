using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour {


    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;

    private BaseObjectGrabable BaseobjectGrabbable;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (BaseobjectGrabbable == null) {
                // Not carrying an object, try to grab
                float pickUpDistance = 4f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask)) {
                    if (raycastHit.transform.TryGetComponent(out BaseobjectGrabbable)) {
                        BaseobjectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            } else {
                // Currently carrying something, drop
                BaseobjectGrabbable.Drop();
                BaseobjectGrabbable = null;
            }
        }
    }
}