using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Flag Stats")]
    public bool hasFlag;
    public bool flagPlaced;
    public int scoreToWin;
    public int curScore;
    public bool gamePaused;

    //instance
    public static GameManager instance;

    void Awake()
    {
        //Set instacne to this script
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //flag bools
        hasFlag = false;
        flagPlaced = false;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(flagPlaced)
        {
            WinGame();
        }
        if(Input.GetButtonDown("Cancel1"))
        {
            TogglePauseGame();
        }
    }
    public void TogglePauseGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f: 1.0f;
        //togglethe pause menu and cursor
        //GameUI.instance.TogglePauseMenu(gamePaused);
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }
    public void AddScore(int score)
    {
        curScore += score;

        //Update score text
        //GameUI.instance. SetEndGameScreen(true, curscore);
    }
    public void WinGame()
    {
        Debug.Log("You've won the game");
        Time.timeScale = 0;
    }
    public void LoseGame()
    {
        Time.timeScale = 0.0f;
        gamePaused = true;
        Debug.Log ("You have lost the game");
    }
    public void PlaceFlag()
    {
        flagPlaced = true;
    }
}
