using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int sceneToLoad;
    private AudioSource mainMenu;
    public AudioClip menu;
    void Start ()
    {
        mainMenu = GetComponent<AudioSource>();
        mainMenu.PlayOneShot(menu, 1.0f);
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad); //Index the scene to load
        Debug.Log("New scene loaded");
    }
    public void QuitGame()
    {
        Application.Quit(); // Quit Game
        Debug.Log("You have quit the game. Goodbye.");
    }
}
