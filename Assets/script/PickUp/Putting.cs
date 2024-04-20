//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using Unity.VisualScripting;
//using UnityEngine;

//public class Putting : MonoBehaviour
//{






//    ObjectGrabbable grabbedObject;
//    GameObject destroyableObject;
//    private void Awake()
//    {
//        GetComponent<ObjectGrabbable>();    
//    }
//    void Start()
//    {
//        destroyableObject = ;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        Debug.Log("Trigger entered: " + other.name);
//        if (other.gameObject.tag == "Bank" && destroyableObject !=null )
//        {
//            Destroy(gameObject);    
//        }

//        else
//        { return; }
//    }









//    //bool isgrabb;
//    //GameObject grabbedObject;

//    //void Start()
//    //{
//    //    // Initialize variables here
//    //    isgrabb = ObjectGrabbable.isGrabbed;
//    //    grabbedObject = ObjectGrabbable.objectGrabObject;
//    //}

//    //private void OnTriggerEnter(Collider other)
//    //{
//    //    Debug.Log(other.name);
//    //    if (isgrabb==true && grabbedObject != null && other.gameObject.tag == "Bank")
//    //    {
//    //        grabbedObject.transform.SetParent(other.transform);
//    //        Debug.Log(isgrabb);
//    //    }
//    //}
//}
