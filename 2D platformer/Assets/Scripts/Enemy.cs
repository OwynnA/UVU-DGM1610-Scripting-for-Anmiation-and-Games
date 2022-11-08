using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy done died.");
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Take that! And that! And a little bit of this!");
    }
}
