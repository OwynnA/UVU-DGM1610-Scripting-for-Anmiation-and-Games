using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int score;//store score value
    public TextMeshProUGUI scoreText;//reference visula text UI element to change
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // this function rewards the player
    public void IncreaseScore(int amount)
    {
        score += amount;//add amount to the score
        UpdateScoreText();//update score text
    }

    //this function penalizes the player
    public void DecreaseScore(int amount)
    {
        score -= amount;// subtract amount from score
        UpdateScoreText();// update scre text
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
