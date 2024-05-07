using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class PickableObject : MonoBehaviour
{
    [SerializeField] private PickableObjectSO PickableObjectSO;

    // We will get the data from object that we picked


    private ContainerObject containerObject;

    public PickableObjectSO GetPickbleObjectSO()
    {

        return PickableObjectSO;

    }


    public void SetContainerObject(ContainerObject containerObject)
    {
        if(this.containerObject != null)
        {
            this.containerObject.ClearPickableObject();
        }

        this.containerObject = containerObject;
        if (containerObject.HasPickableObject())
        {
            Debug.LogError("it is already has an item in its slot");
        }
        containerObject.SetPickableObject(this);
        
        transform.parent = containerObject.GetSlotPointTransform();
        transform.localPosition= Vector3.zero; transform.localRotation = Quaternion.identity;
    }


    public ContainerObject GetDestroyBank()
    {
        return containerObject;
    }

}
