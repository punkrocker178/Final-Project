﻿
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text roundsText;

    void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel() {
        if (PlayerStats.GetNextLevel() != null) {
            SceneManager.LoadScene(PlayerStats.GetNextLevel().levelName);
        }
    }
}
