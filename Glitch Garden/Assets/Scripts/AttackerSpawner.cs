using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    [SerializeField] Attacker[] attackers;
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

    //chooses random index and calls spawn method in order to spawn the random unit
    private void SpawnAttacker()
    {
        int randomIndex = Random.Range(0, attackers.Length);
        Spawn(attackers[randomIndex]);
    }

    //actually spawns the unit
    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position,
           transform.rotation) as Attacker;
        //make the instantiated attackers children of the spawner
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning() { spawn = false; }
}
