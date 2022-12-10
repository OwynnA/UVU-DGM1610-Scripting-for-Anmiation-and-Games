using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed;
    public float jumpForce;
    public float curHP;
    public float maxHP;

    [Header("Camera")]
    public float lookSensitivity;
    public float maxLookX;
    public float minLookX;
    private float rotX;
    private Camera camera;
    private Rigidbody rb;

    [Header("Audio")]
    private AudioSource takeDamage;
    public AudioClip ouch;

    void Awake()
    {
        curHP = maxHP;
        //Get Components
        camera = Camera.main;
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        takeDamage = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CameraLook();
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        
    }
    public void TakeDamage(int damage)
    {
        curHP -= damage;
        takeDamage.PlayOneShot(ouch, 0.5f);
        if(curHP <= 0)
        {
            Die();
        }

        //GameUI.instance.UpdateHealthBar(curHP, maxHP);
    }
    void Die()
    {
        //GameManager.instance.LoseGame();
        Debug.Log("You done died");
        Time.timeScale = 0;
    }
    void LoseGame()
    {
        Debug.Log("the game is lost");
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed; //getting imput for left and right movement
        float z = Input.GetAxis("Vertical") * moveSpeed; //getting input for forward and back movement
        Vector3 dir = (transform.right * x) + (transform.forward * z);
        dir.y = rb.velocity.y;
        rb.velocity = dir;

    }
    void CameraLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity; //look up and down
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity; //lookleft and right
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX); // restrict rotation on the x axis from min to maxLookX
        //drives camera rotation
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }
    void Jump()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(ray, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
     public void GiveHealth(int amountToGive)
    {
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
    }
     public void GiveAmmo(int amountToGive)
    {
        //weapon.curAmmo = Mathf.Clamp(curHp + amountToGive, 0, weapon.maxAmmo);
    }
}