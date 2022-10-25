using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float hInput;
    public int speed;
    private float xRange = 22.5f;
    public GameObject LazerBeam;
    public Transform Blaster;

    private AudioSource blasterAudio;
    public AudioClip laserBlast;

    private AudioSource backgroundAudio;
    public AudioClip background;
    // Start is called before the first frame update
    void Start()
    {
        blasterAudio = GetComponent<AudioSource>();
        backgroundAudio = GetComponent<AudioSource>();
        backgroundAudio.PlayOneShot(background,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * hInput * speed * Time.deltaTime);

        if(transform.position.x >xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(transform.position.x< -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            blasterAudio.PlayOneShot(laserBlast,1.0f);
            Instantiate(LazerBeam, Blaster.transform.position, LazerBeam.transform.rotation);
        }
    }
}
