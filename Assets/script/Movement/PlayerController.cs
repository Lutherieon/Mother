using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPS : MonoBehaviour
{

    [SerializeField] float speed = 5.0f;
    private float m_MovX;
    private float m_MovY;
    private Vector3 m_moveHorizontal;
    private Vector3 m_movVertical;
    private Vector3 m_velocity;
    private Rigidbody m_Rigid;
    private float m_yRot;
    private float m_xRot;
    private Vector3 m_rotation;
    private Vector3 m_cameraRotation;
    private float m_lookSensitivity = 3.0f;
    private bool m_cursorIsLocked = true;
    public float jumpSpeed = 250f;
    [SerializeField]Collider m_collider;
    public float maxDistanceRay = 0.01f;
    [SerializeField] LayerMask flour;
    [SerializeField] Vector3 offset;
    bool isgrounded;

    [Header("The Camera the player looks through")]
    public Camera m_Camera;

    // Use this for initialization
    private void Start()
    {
        m_Rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        isGrounded();

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            m_Rigid.velocity = Vector3.up * jumpSpeed * Time.deltaTime;

        }

        m_MovX = Input.GetAxis("Horizontal");
        m_MovY = Input.GetAxis("Vertical");

        m_moveHorizontal = transform.right * m_MovX;
        m_movVertical = transform.forward * m_MovY;

        m_velocity = (m_moveHorizontal + m_movVertical).normalized * speed;

        //mouse movement 
        m_yRot = Input.GetAxisRaw("Mouse X");
        m_rotation = new Vector3(0, m_yRot, 0) * m_lookSensitivity;

        m_xRot = Input.GetAxisRaw("Mouse Y");
        m_cameraRotation = new Vector3(m_xRot, 0, 0) * m_lookSensitivity;

        //apply camera rotation

        //move the actual player here
        if (m_velocity != Vector3.zero)
        {
            m_Rigid.MovePosition(m_Rigid.position + m_velocity * Time.fixedDeltaTime);
        }

        if (m_rotation != Vector3.zero)
        {
            //rotate the camera of the player
            m_Rigid.MoveRotation(m_Rigid.rotation * Quaternion.Euler(m_rotation));
        }

        if (m_Camera != null)
        {
            //negate this value so it rotates like a FPS not like a plane
            m_Camera.transform.Rotate(-m_cameraRotation);
        }

        InternalLockUpdate();

    }

    //controls the locking and unlocking of the mouse
    private void InternalLockUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            m_cursorIsLocked = false;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            m_cursorIsLocked = true;
        }

        if (m_cursorIsLocked)
        {
            UnlockCursor();
        }
        else if (!m_cursorIsLocked)
        {
            LockCursor();
        }
    }


























    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    private void isGrounded()
    {
        RaycastHit raycastHit;
        isgrounded = Physics.BoxCast(m_collider.bounds.center - offset, m_collider.bounds.size * 0.5f, Vector3.down, out raycastHit ,Quaternion.identity,maxDistanceRay, flour, QueryTriggerInteraction.UseGlobal);
        Color rayColor;


        
        
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(m_collider.bounds.center, Vector2.down * (m_collider.bounds.extents.y + maxDistanceRay), rayColor);
        //Debug.Log(raycastHit2D.collider);

        if (isgrounded)
        {
            Debug.Log("hit:" + raycastHit.collider.name);
            //rb.velocity = Vector3.zero;
        }

    }

}