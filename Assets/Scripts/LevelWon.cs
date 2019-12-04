using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelWon : MonoBehaviour
{
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
