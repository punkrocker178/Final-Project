using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public static SaveObject save;
    public static int numberOfLevels = 12;
    public int starterMoney = 400;
    public int StartLives = 20;


    public static int Rounds;
    private static string path = Application.dataPath + "/Save/Levels.json";


    void Start()
    {
        Money = starterMoney;
        Lives = StartLives;
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
        JsonUtility.ToJson<SaveObject>(save);
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
