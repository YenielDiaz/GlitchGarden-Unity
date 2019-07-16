﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    [SerializeField] Attacker lizardPrefab;
    [SerializeField] float minDelay = 1;
    [SerializeField] float maxDelay = 5;

    IEnumerator Start()
    {
        do
        {          
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
            SpawnAttacker();
        }
        while (spawn);
    }

    private void SpawnAttacker()
    {
       Attacker newAttacker = Instantiate(lizardPrefab, transform.position,
           transform.rotation) as Attacker;
        //make the instantiated attackers children of the spawner
        newAttacker.transform.parent = transform; 
    }
    void Update()
    {
        
    }
}
