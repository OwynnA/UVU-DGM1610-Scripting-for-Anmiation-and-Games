using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private float speed;
    public int damage = 10;
    public Rigidbody2D rb;
    private bool isFacingRight = true;
    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
         if(!isFacingRight == false & done == true)
         {
            
            speed = -30f;
            done = false;
            isFacingRight = true;
            rb.velocity = transform.right * speed;
         }

        //if player is moving left but facing right flip player left
        if(isFacingRight == true & done == false)
        {
            speed = 30f;
            Debug.Log("Are we getting here");
            done = true;
            isFacingRight = false;
            rb.velocity = transform.right * speed;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        GhostEnemy enemy = other.GetComponent<GhostEnemy>();
        if(other.gameObject.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
        }
        Destroy (gameObject);
    }
}