using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider diffSlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] float defaultDifficulty = 1f;

    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        diffSlider.value = PlayerPrefsController.GetDifficulty();
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.Log("No music player found (did you start fro splash screen?)");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(diffSlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void DefaultValues()
    {
        volumeSlider.value = defaultVolume;
        diffSlider.value = defaultDifficulty;
    }
}
