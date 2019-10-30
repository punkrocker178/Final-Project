using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public int starterMoney = 400;
    public int StartLives = 20;


    void Start()
    {
        Money = starterMoney;
        Lives = StartLives;
    }
}
