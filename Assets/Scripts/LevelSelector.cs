using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    void Start() {
        GameObject[] levels = GameObject.FindGameObjectsWithTag("LevelButtons");
        PlayerStats.LoadSave();
        PlayerStats.SaveObject save = PlayerStats.save;
        for(int i = 0; i< levels.Length; i++ ) {
            Debug.Log(save);
            if (save.levels[i].unlocked) {
                levels[i].GetComponent<Button>().interactable = true;
            } else {
                levels[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    public void Select (string levelName) {
        SceneManager.LoadScene(levelName);
    }
}
