using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public float deathDelay;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int dmgAmount)
    {
        currentHealth -= dmgAmount;
        
        if(currentHealth <= 0)
        {
            Destroy(gameObject, deathDelay);
        }
    }

    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount; //how much does the player heal
        if(currentHealth >= maxHealth) //puts a cap on health so it can't go over the max
        {
            currentHealth = maxHealth;
        }
    }
}
