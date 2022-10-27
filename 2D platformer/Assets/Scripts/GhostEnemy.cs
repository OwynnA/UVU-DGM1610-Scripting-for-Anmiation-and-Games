using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) // is the dead enemy more dead yet
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
