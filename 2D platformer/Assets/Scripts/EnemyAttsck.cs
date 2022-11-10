using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttsck : MonoBehaviour
{
    private Health PlayerHealth;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHeath = GameObject.Find("Player").GetComponent("PlayerHealth"); //find PlayerHealth Script
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEneter2D(Collision2D other)
    {
        if(other.CompareTag("Player"))
        {
            PLayerHealth.TakeDamage();
        }
    }
}
