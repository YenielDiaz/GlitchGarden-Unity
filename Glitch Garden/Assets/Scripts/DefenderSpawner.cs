using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender unitToSpawn;

    private void OnMouseDown()
    {
        //Debug.Log("Mouse clicked");
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }
    private Vector2 GetSquareClicked()
    {
        //gets pos where mouse is
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //converts mouse pos to world units
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        //snapping worldPos to Grid
        Vector2 gridPos = snapToGrid(worldPos);
        //return final position
        return gridPos;
    }

    private Vector2 snapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        unitToSpawn = selectedDefender;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = unitToSpawn.GetStarCost();

        //if we have enough stars ***and if there is no unit in given pos***
        //spawn defender
        //spend stars
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SubtractStars(defenderCost);
        }
    }

    private void SpawnDefender(Vector2 location)
    {
        Defender newDefender = Instantiate(unitToSpawn, location, 
            Quaternion.identity) as Defender;
    }
}
