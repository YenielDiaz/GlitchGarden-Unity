using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    private void Start()
    {
        LabelButtonWithCost();
    }

    private void LabelButtonWithCost()
    {
        Text costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogError(name + " has no cost text, add some!");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons) // this loop changes the color of every unit button to unselected
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(96,92,92,255);
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white; //changes selected button color to white
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);//let spawner know chosen defender
    }
}
