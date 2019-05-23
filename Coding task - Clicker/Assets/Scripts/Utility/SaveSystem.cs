using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    private static string _dataKey = "Highscore";

    public static void SaveHighscore(float score)
    {
        PlayerPrefs.SetFloat(_dataKey, score);
        PlayerPrefs.Save();
    }

    public static float? LoadHighscore()
    {
        if (PlayerPrefs.HasKey(_dataKey))
        {
            return PlayerPrefs.GetFloat(_dataKey);
        }
        else
        {
            return null;
        }
    }

    public static void ResetHighscore()
    {
        PlayerPrefs.DeleteKey(_dataKey);
        PlayerPrefs.Save();
    }
}
