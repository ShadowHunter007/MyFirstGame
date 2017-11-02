using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform groundCheck;
    public LayerMask whatIsGround;
    private Rigidbody2D rb;

    public float jumpForce = 200f;
    public float sprintSpeed = 5f;
    public float walkSpeed = 2f;
    private float speed = 2f;
    private float groundRadius = 0.1f;

    private bool facingRight = true;
    private bool grounded = false;

    void Start () {

        rb = GetComponent<Rigidbody2D>();

        //prevent character from falling over
        rb.freezeRotation = true;
    }
	
	void FixedUpdate () {
  
        //Check if player is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        //Get horizontal move input
        float move = Input.GetAxis("Horizontal");

        //Set speed
        if (Input.GetKey("left shift"))
            speed = sprintSpeed;
        else
            speed = walkSpeed;

        //Apply speed
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        //Flip character 
        if(move > 0 && !facingRight)
            Flip();
        else if(move < 0 && facingRight)
            Flip();
    }

    void Update()
    {
        //If player is grounded and pressed space: 
        //(y velocity check is to prevent space spamming)
        if(grounded && Input.GetKeyDown(KeyCode.Space) && rb.velocity.y < 0.1)
        {
            //Jump
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
