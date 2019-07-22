using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab, gun;
    [SerializeField] AttackerSpawner myLaneSpawner;
    Animator animator;

    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "projectiles";
    

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAttackerInLane())
        {
            //sets trigger bool variable to true if there is an attacker in the same lane
            animator.SetBool("isAttacking", true);
        }
        else
        {
            //sets trigger variable to false if there is not an attacker in the same lane
            animator.SetBool("isAttacking", false);
        }
    }
    public void Fire(float speed)
    {
        GameObject newProjectile = Instantiate(projectilePrefab,
            gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;

    }

    private bool IsAttackerInLane()
    {
        //if child count of lane spawner is <= then 0 return false
        if (myLaneSpawner.transform.childCount <= 0) return false;
        return true;
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawners)
        {
            //if the absolute value of the remainder of spawner's y and shooter's y is less than
            //the smallest number (Epsilon), then it is this lane's spawner;
            bool isCloseEnough = 
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
                return;
            }
        }
    }
}
