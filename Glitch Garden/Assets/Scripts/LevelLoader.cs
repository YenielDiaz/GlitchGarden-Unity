using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int loadDelay = 3;
    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //we can use this when going through scenes in order
        StartCoroutine(LoadAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene("StartScreen");
    }
}
