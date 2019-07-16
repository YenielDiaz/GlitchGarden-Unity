using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starcost;
    //[SerializeField] int coolDownTime;

    //we use this method in order to use the addstar method fro stardisplay in the animator
    //for objects of type defender
    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    public int GetStarCost() { return starcost;  }
}
