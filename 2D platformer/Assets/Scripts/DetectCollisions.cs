using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public ScoreManager scoreManager;
    public int scoreToGive;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D Other)
    {
        scoreManager.IncreaseScore(scoreToGive);
        Destroy(gameObject);
    }
}
