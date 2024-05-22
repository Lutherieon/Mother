using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    public BankType type;
    public enum BankType
    {
        Priz,
        WashMachine,
        Microwave,
        Perde
    }
}
