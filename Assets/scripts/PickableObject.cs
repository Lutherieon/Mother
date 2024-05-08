using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHS;

public class PickableObject : MonoBehaviour
{
    [SerializeField] private PickableObjectSO PickableObjectSO;

    // We will get the data from object that we picked


    private IpickableObjectParent PickableObjectParent;

    public PickableObjectSO GetPickbleObjectSO()
    {

        return PickableObjectSO;

    }


    public void SetPickableObjectParent(IpickableObjectParent PickableObjectParent)
    {
        if(this.PickableObjectParent != null)
        {
            this.PickableObjectParent.ClearPickableObject();
        }

        this.PickableObjectParent = PickableObjectParent;
        if (PickableObjectParent.HasPickableObject())
        {
            Debug.LogError("it is already has an item in its slot");
        }
        PickableObjectParent.SetPickableObject(this);
        
        transform.parent = PickableObjectParent.GetSlotPointTransform();
        transform.localPosition= Vector3.zero; transform.localRotation = Quaternion.identity;
    }


    public IpickableObjectParent GetPickableObjectParent()
    {
        return PickableObjectParent;
    }

}
