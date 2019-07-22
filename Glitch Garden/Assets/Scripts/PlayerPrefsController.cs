using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0;
    const float MAX_VOLUME = 1;

    const float MIN_DIFF = 1;
    const float MAX_DIFF = 3;

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
        {
            Debug.Log("Value not in range");
        }
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFF && difficulty <= MAX_DIFF)
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        else
        {
            Debug.Log("Value not in range");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
