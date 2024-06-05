using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
public class Fork : BaseObjectGrabable
{
    [Header ("THINGS IT AFFECTS")]
    public ParticleSystem ParticleSystem;
    private AudioManager audioManager;
    [SerializeField] private CharacterMovement characterController;

    [Header (" Grabbing Mechanic ")]
    public static bool isGrabbed;
    private Rigidbody rb;
    public Transform objectGrabPointTransform;
    public GameObject objectGrabObject;
    public GameObject point;

    [Header (" Friend Manager?")]
    private FriendManager friendManager;

    [Header("Timer")]
    private float currentTime;
    private bool electricitySpeed;

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
        electricitySpeed = false;
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
        electricityPowerUp();
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
        if (other.gameObject.tag == "Bank" && other.GetComponent<Bank>().type == Bank.BankType.Microwave)
        {
            //Destorying the object that we hold
            Destroy(objectGrabObject);

            //Activate particle system
            ParticleSystem.Play();

            //Change the veve's visual state
            friendManager.veveState = friendManager.veveState_Electro;

            //Play the audio 
            audioManager.PlaySFX(audioManager.ElectMicroWave);

            //Increase the score 
            ScoreManager.score += 100;

            //Activate the electricityPowerUp
            electricitySpeed = true;

            TimeScript.TimeLeft += 5f;


        }

        else
        {
            Debug.Log("bu banka bu objeye uygun degil!");
        }
    }

    void electricityPowerUp()
    {
        if(electricitySpeed == true)
        {
            currentTime += Time.deltaTime;
            if(currentTime < 5f)
            {
                characterController.walkingSpeed += 5f;
                characterController.runningSpeed += 5f;

            }
            else if(currentTime > 5f)
            {
                characterController.walkingSpeed -= 5f;
                characterController.runningSpeed -= 5f;
                
            }
        }
    }


}


