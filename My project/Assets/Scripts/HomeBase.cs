using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBase : MonoBehaviour
{
    private GameManager gm;
    private Renderer flagRend;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        flagRend = GameObject.Find("FlagHome").GetComponent<Renderer>();
        flagRend.enabled = false; // hide the flag
    }
    void OnTriggerEnter(Collider Other)
    {
       if(Other.CompareTag("Player") && gm.hasFlag)
        {
            Debug.Log("Player has reached home base");
            gm.PlaceFlag(); // run place flag function in gmae manager
            flagRend.enabled = true; //Make flag visible

        }
    }
}
