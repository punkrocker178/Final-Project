using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public static bool LevelIsWon;
    public GameObject gameOverUI;
    public GameObject levelWonUI;

    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }

        if (WaveSpawner.IsStopped) {
            WinGame();
        }

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    void WinGame() {
        PlayerStats.UpdateLevel(PlayerStats.GetCurrentLevel());
        levelWonUI.SetActive(true);
        LevelIsWon = true;
    }
}
