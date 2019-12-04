using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public static SaveObject save;
    public static int numberOfLevels = 12;
    public static string CurrentLevel;
    public int starterMoney = 400;
    public int StartLives = 20;


    public static int Rounds;
    private static string path;

    void Awake() {
        path = Application.dataPath + "/Save/Levels.json";
    }

    void Start()
    {
        Money = starterMoney;
        Lives = StartLives;
        CurrentLevel = SceneManager.GetActiveScene().name;
    }

    public static void LoadSave() {
        if(File.Exists(path)) {
           save = JsonUtility.FromJson<SaveObject>(File.ReadAllText(path));
           Debug.Log(save.levels[0].unlocked);
        } else {
           save = new SaveObject();
           save.levels[0] = new Level("level01", true);
        }
    }

    public static void WriteSave() {
        string json = JsonUtility.ToJson(save);
        File.WriteAllText(path, json);
    }

    public static void UpdateLevel(Level currentLevel) {
        for (int i = 0; i < save.levels.Length - 1 ; i++) {
            if (save.levels[i].levelName == currentLevel.levelName) {
                save.levels[i+1].unlocked = true;
                break;
            }
        }
        WriteSave();
    }

    public static Level GetCurrentLevel() {
        foreach (Level level in save.levels)
        {
            if (level.levelName == CurrentLevel) {
                return level;
            }          
        }
        return null;
    }

    public static Level GetNextLevel() {
        for (int i = 0; i < save.levels.Length - 1; i++ ) {
            if (save.levels[i].levelName == CurrentLevel) {
                return save.levels[i+1];
            }          
        }
        return null;
    }

    public class SaveObject {
       public Level[] levels;

       public SaveObject() {
           levels = new Level[PlayerStats.numberOfLevels];;
       }
    }

    [System.Serializable]
    public class Level {
        public string levelName;
        public bool unlocked;

        public Level(string levelName, bool unlocked) {
            this.levelName = levelName;
            this.unlocked = unlocked;
        }
    }
}
