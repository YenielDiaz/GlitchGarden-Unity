﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100;
    //[SerializeField] AudioClip deathSFX;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //play death SFX
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }

        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}
