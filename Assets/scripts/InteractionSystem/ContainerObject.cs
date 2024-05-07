using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace VHS
{
    public class ContainerObject : InteractableBase
    {
        [SerializeField] private PickableObjectSO PickableObjectSO;
        [SerializeField] private Transform Slot;
        private PickableObject PickableObject;

        [SerializeField] private ContainerObject secondDestroyInteractable;
        [SerializeField] public bool isTesting;

        private void Awake()
        {

        }



        private void Update()
        {
            if(isTesting && Input.GetKeyDown(KeyCode.T))
            {
                if(PickableObject != null)
                {
                    PickableObject.SetContainerObject(secondDestroyInteractable);
                    //Debug.Log(PickableObject.GetDestroyBank());
                }
            }
        }
        public override void OnInteract()
        { 
            //tek obje olusturmaya calis hala yapamadin . halledildi


            

            
            base.OnInteract();
            if(PickableObject == null)
            {
                Debug.Log("Interacted.");
           
                Transform pickableObjectTransform = Instantiate(PickableObjectSO.prefab, Slot);
                pickableObjectTransform.GetComponent<PickableObject>().SetContainerObject(this);
                //pickableObjectTransform.localPosition = Vector3.zero;

                //PickableObject = pickableObjectTransform.GetComponent<PickableObject>();
                //PickableObject.SetContainerObject(this);
                //Debug.Log(pickableObjectTransform.GetComponent<PickableObject>().GetPickbleObjectSO());
            }
            else
            {
                Debug.Log(PickableObject.GetDestroyBank());
            }
            


           
        }

        public Transform GetSlotPointTransform()
        {

            return Slot;
        }



        public void SetPickableObject(PickableObject pickableObject)
        {
            this.PickableObject = pickableObject;   

        }

        public PickableObject GetPickableObject()
        {
            return PickableObject;
        }


        public void ClearPickableObject()
        {
            PickableObject = null;  
        }


        public bool HasPickableObject()
        {
            return PickableObject != null;
        }
    }

}
