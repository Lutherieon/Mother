using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    [SerializeField] LayerMask interactableLayerMask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(Camera.main.transform.position, interactRange, interactableLayerMask);
            foreach(Collider collider in colliderArray) 
            {
                if(collider.TryGetComponent(out NpcInteractable npcInteractable))
                {
                    npcInteractable.NpcInteractable_();
                }

            }
        }
    }
}
