//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using Unity.VisualScripting;
//using UnityEngine;
//namespace VHS
//{
//    public class ObjectGrabbable : BaseObjectGrabable
//    {
//        public static bool isGrabbed;
//        private Rigidbody rb;
//        public Transform objectGrabPointTransform;
//        public GameObject objectGrabObject;

//        private void Awake()
//        {
//            rb = GetComponent<Rigidbody>();
//            isGrabbed = false;
//        }
//        public override void Grab(Transform ObjectGrabPointTransform)
//        {
//            this.objectGrabPointTransform = ObjectGrabPointTransform;
//            objectGrabObject = this.gameObject;
//            Debug.Log(objectGrabObject);
//            isGrabbed = true;
//            Debug.Log(isGrabbed);
//            rb.useGravity = false;
//        }

//        public override void Drop()
//        {
//            this.objectGrabPointTransform = null;
//            isGrabbed = false;
//            rb.useGravity = true;
//        }

//        private void FixedUpdate()
//        {
//            if (objectGrabPointTransform != null)
//            {
//                float lerpSpeed = 15f;
//                Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, lerpSpeed * Time.deltaTime);

//                rb.MovePosition(newPosition);
//                rb.velocity = Vector3.zero;
//            }
//        }
      



//        private void OnTriggerEnter(Collider other)
//        {
//            if (other.gameObject.tag == "Bank")
//            {
//                Destroy(objectGrabObject);
//                ScoreManager.score += 100;
//            }
//        }
//    }

//}



