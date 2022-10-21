using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void IncreaseScore(int amount)
    {
        score += amount;//add amount to the score
        UpdateScoreText();//update score text
    }
     void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
