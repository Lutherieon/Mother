using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool hasKnife = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
void OnTriggerEnter(Collider other) {
    if (other.tag == "knife"){
        hasKnife = true;
    }
    if (other.tag == "oven"&&hasKnife){
        
    }
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
