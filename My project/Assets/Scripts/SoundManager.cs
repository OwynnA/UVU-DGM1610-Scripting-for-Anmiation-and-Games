using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource healthPickup;
    public AudioClip health;
    // Start is called before the first frame update
    void Start()
    {
        healthPickup = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void HealthSFX()
    {
        healthPickup.PlayOneShot(health, 1.0f);
        Debug.Log("You have been healed");
    }
}
