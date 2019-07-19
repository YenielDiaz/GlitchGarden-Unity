using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    //notice it's not on collision enter but collision stay
    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attacker = collision.GetComponent<Attacker>();
        if (attacker)
        {
            //TODO do some sort of animation
        }
    }
}
