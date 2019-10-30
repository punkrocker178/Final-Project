using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Text lives;
    // Update is called once per frame
    void Update()
    {
        lives.text = "Life: " + PlayerStats.Lives.ToString();
    }
}
