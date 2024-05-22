using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : BaseObjectGrabable
{
    [Header("THINGS IT AFFECTS")]
    public ParticleSystem ParticleSystem1;
    public ParticleSystem ParticleSystem2;
    public ParticleSystem ParticleSystem3;
    public ParticleSystem ParticleSystem4;
    private AudioManager audioManager;
    [SerializeField] private CharacterMovement characterController;

    [Header(" Grabbing Mechanic ")]
    public static bool isGrabbed;
    private Rigidbody rb;
    private Transform objectGrabPointTransform;
    private GameObject objectGrabObject;
    private GameObject point;

    [Header(" Friend Manager?")]
    private FriendManager friendManager;

    [Header("Timer")]
    private float currentTime;

    private void Awake()
    {
        characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        friendManager = GameObject.FindGameObjectWithTag("FriendManager").GetComponent<FriendManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        rb = GetComponent<Rigidbody>();
        isGrabbed = false;
    }
    private void Start()
    {

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

    private void Update()
    {
        Debug.Log(currentTime);
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
        if (other.gameObject.tag == "Bank" && other.GetComponent<Bank>().type == Bank.BankType.Perde)
        {
            //Destorying the object that we hold
            Destroy(objectGrabObject);

            //Activate particle system
            ParticleSystem1.Play();
            ParticleSystem2.Play();
            ParticleSystem3.Play();
            ParticleSystem4.Play();

            //Change the veve's visual state
            //friendManager.veveState = friendManager.veveState_Electro;

            //Play the audio 
            audioManager.PlaySFX(audioManager.FireBigSound);

            //Increase the score 
            ScoreManager.score += 100;

        }

        else
        {
            Debug.Log("bu banka bu objeye uygun degil!");
        }
    }

}
