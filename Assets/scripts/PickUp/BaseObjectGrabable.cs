using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjectGrabable : MonoBehaviour
{
    public virtual void Grab(Transform ObjectGrabPointTransform)
    {
        Debug.LogError("BaseObjectGrabable.Grab();");
    }

    public virtual void Drop()
    {
        Debug.LogError("BaseObjectGrabable.Drop();");
    }
}
