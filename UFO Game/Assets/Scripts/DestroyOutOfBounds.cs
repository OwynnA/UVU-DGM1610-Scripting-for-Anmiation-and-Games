using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBounds = 30.0f;
    public float lowerBounds = -10.0f;
    private ScoreManager scoreManager;
    private DetectCollisions detectCollision;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        detectCollision = GetComponent<DetectCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBounds)
        {
            scoreManager.DecreaseScore(detectCollision.scoreToGive);//every time a ship sneaks past the lower bounds, decrease the score
            Destroy(gameObject);
        }
    }

}
