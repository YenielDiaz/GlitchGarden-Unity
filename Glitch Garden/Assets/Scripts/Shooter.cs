using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab, gun;

    public void Fire(float speed)
    {
        var projectile = Instantiate(projectilePrefab, gun.transform.position, transform.rotation);

    }
}
