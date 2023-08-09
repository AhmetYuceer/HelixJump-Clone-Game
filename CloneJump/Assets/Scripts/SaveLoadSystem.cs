using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    public static int level;
    public static int nextLevel;
    public static float xp;
    public static void Save()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("level",level);
        PlayerPrefs.SetInt("nextLevel",nextLevel);
        PlayerPrefs.SetFloat("xp",xp);
        PlayerPrefs.Save();
    }
    public static bool Load()
    {
       if (PlayerPrefs.HasKey("level") && PlayerPrefs.HasKey("nextLevel") && PlayerPrefs.HasKey("xp") )
       {
            level = PlayerPrefs.GetInt("level",level);
            nextLevel = PlayerPrefs.GetInt("nextLevel",nextLevel);
            xp = PlayerPrefs.GetFloat("xp",xp);
            return true;
       }
       return false;
    }
}
