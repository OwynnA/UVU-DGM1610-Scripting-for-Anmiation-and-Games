using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;

    //player rigidbody
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    //player Jump
    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    // fixed update is called a fixed or set number of frames. This works best with physics based movement
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //if the player is moving right but facing left flip the player right
        if(!isFacingRight & moveInput > 0)
        {
            FlipPlayer();
        }

        //if player is moving left but facing right flip player left
        if(isFacingRight & moveInput < 0)
        {
            FlipPlayer();
        }
    }
    void Update()
    {
        if(isGrounded)
        {
            doubleJump = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            rb.velocity = Vector2.up * jumpForce; // makes the player jump
            doubleJump = false;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !doubleJump && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
