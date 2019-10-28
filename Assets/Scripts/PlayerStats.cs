using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int starterMoney = 400;

    void Start()
    {
        Money = starterMoney;
    }
}
