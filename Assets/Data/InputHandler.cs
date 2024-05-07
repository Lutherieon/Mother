using System;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using VHS;
public class InputHandler : MonoBehaviour
{
    #region Data
    [BoxGroup("Input Data")]
    public InteractionInputData interactionInputData;
    private PlayerInput playerInput;
    public event EventHandler OnInteractAction;
    #endregion

    #region BuildIn Methods

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Plyer.Enable();
        playerInput.Plyer.Interact.performed += Interact_performed;
    }
    #region Events
    private void Interact_performed(InputAction.CallbackContext obj)
    {

        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    #endregion 
    private void Start()
    {
        interactionInputData.ResetInput();
    }
    #endregion

    private void Update()
    {
        GetInteractionInput();
    }



    #region CustomMethods
    void GetInteractionInput()
    {
        interactionInputData.InteractedClicked = Input.GetKeyDown(KeyCode.E);
        //Debug.Log("InteractedClicked" + interactionInputData.InteractedClicked);
        interactionInputData.InteractedRelease = Input.GetKeyUp(KeyCode.E);
        //Debug.Log("InteractedRelease" + interactionInputData.InteractedRelease);



    }

    #endregion






}




