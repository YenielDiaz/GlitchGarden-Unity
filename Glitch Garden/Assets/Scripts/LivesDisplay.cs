using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] int life = 3;
    [SerializeField] int damageTaken = 1;
    Text livesText;

    void Start()
    {
        livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = "Health:" + life.ToString();
    }

    public void DecreaseLife()
    {
        life -= damageTaken;
        UpdateDisplay();

        if(life <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            //FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }

}
