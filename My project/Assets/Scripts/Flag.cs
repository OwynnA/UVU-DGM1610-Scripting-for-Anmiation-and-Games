using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private GameManager gm;
    private Renderer rend;

    private AudioSource flagPickup;
    public AudioClip flag;
    // Start is called before the first frame update
    void Start()
    {
        flagPickup = GetComponent<AudioSource>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>(); //find game manager and reference game manager script
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider Other)
    {
        flagPickup.PlayOneShot(flag, 1.0f);
        gm.hasFlag = true; // get flag and set has flag variable to true
        rend.enabled = false; // turn off the mesh to make flag invisible
    }
}
