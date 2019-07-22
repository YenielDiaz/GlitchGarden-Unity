using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int loadDelay = 3;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //we can use this when going through scenes in order
        if(currentSceneIndex == 0) StartCoroutine(LoadAfterDelay());
    }


    private IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene("StartScreen");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("OptionsScreen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
