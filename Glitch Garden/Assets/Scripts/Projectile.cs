using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float damage = 50;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    //maybe its better to deal with taking damage on the attacker script //////////////////////////
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemyHealth = collision.GetComponent<Health>();
        var enemyAttacker = collision.GetComponent<Attacker>();

        if(enemyHealth && enemyAttacker)
        {
            enemyHealth.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
