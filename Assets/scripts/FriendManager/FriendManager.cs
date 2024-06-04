using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendManager : MonoBehaviour
{
    [SerializeField] public Sprite veveState;
    [SerializeField] public Sprite veveState_IDLE, veveState_EVIL, veveState_Electro, veve_Drunk;
    [SerializeField] private Image veveStateImage;



    private void Start()
    {
        veveState = veveState_IDLE;
    }
    private void Update()
    {
        veveStateImage.sprite = veveState;
    }




}
