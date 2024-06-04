using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using VHS;

public class Bottle : InteractableBase
{
    [SerializeField] FriendManager friendManager;
    [SerializeField] private Volume volume;
    [SerializeField] private VolumeProfile profile;
    public override void OnInteract()
    {
        base.OnInteract();
        //Increase the stats.
        //Give drunk model
        volume.profile = profile;
        friendManager.veveState = friendManager.veve_Drunk;
        
    }
}
