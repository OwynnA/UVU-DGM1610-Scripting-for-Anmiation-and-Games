using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 10;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        GhostEnemy enemy = other.GetComponent<GhostEnemy>();
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Did it work?");
            enemy.TakeDamage(damage);
        }
        Debug.Log("Did the bullets go away or no?");
        Destroy (gameObject);
    }
}
