using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public class Fork : BaseObjectGrabable
{
    public static bool isGrabbed;
    private Rigidbody rb;
    public Transform objectGrabPointTransform;
    public GameObject objectGrabObject;
    public GameObject point;
    public ParticleSystem ParticleSystem;
    private AudioManager audioManager;
    private FriendManager friendManager;

    private void Awake()
    {
        friendManager = GameObject.FindGameObjectWithTag("FriendManager").GetComponent<FriendManager>();    
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody>();
        isGrabbed = false;
    }
    public override void Grab(Transform ObjectGrabPointTransform)
    {

        this.objectGrabPointTransform = ObjectGrabPointTransform;
        objectGrabObject = this.gameObject;
        Debug.Log(objectGrabObject);
        isGrabbed = true;
        Debug.Log(isGrabbed);
        rb.useGravity = false;
    }

    public override void Drop()
    {
        this.objectGrabPointTransform = null;
        isGrabbed = false;
        rb.useGravity = true;


    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 15f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, lerpSpeed * Time.deltaTime);

            rb.MovePosition(newPosition);
            rb.velocity = Vector3.zero;
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bank")
        {
            if(other.GetComponent<Bank>().type == Bank.BankType.Microwave)
            {

            }
            Destroy(objectGrabObject);
            ParticleSystem.Play();
            friendManager.veveState = friendManager.veveState_Electro;
            audioManager.PlaySFX(audioManager.ElectMicroWave);

            ScoreManager.score += 100;
        }
    }
}


