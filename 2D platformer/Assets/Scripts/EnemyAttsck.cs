using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttsck : MonoBehaviour
{
    private Health playerHealth;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<Health>(); //find PlayerHealth Script
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
