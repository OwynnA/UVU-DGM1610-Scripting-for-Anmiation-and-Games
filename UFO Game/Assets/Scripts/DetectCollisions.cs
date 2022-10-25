using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public ScoreManager scoreManager;// avariable to hold a reference to the score manager
    public int scoreToGive;
    public ParticleSystem explosionParticle; //store the particel system
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();// reference score manager
    }
    

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("well something happened");
        Explosion();
        scoreManager.IncreaseScore(scoreToGive); //increase score
        Destroy(gameObject); // destory this game object
        Destroy(other.gameObject); // destroy the other game object
    
    }
    void Explosion()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);//make particles exist
    }
}
