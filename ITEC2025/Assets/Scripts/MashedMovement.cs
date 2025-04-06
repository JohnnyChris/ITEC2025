using UnityEngine;

public class MashedMovement : MonoBehaviour
{
    public float speed = 5f;
    public float stoppingSpeed = 0.5f;
    public float accelerationSpeed = 1f;
    public float jumpSpeed = 3f;
    public float wallSlideSpeed = 0.5f;
    public float climbSpeed = 2f;

    private Rigidbody2D rb;
    

    private float lastVelocity;
    float step;
    private bool stoppedMoving;
    private bool startedMoving;

    public LayerMask groundLayer;
    public LayerMask wall;

    private bool isOnWall;
    private bool isTouchingWallLeft;
    private bool isTouchingWallRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;

        // Wall detection (short raycast on both sides)
        isTouchingWallLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.8f, wall);
        isTouchingWallRight = Physics2D.Raycast(transform.position, Vector2.right, 0.8f, wall);
        isOnWall = isTouchingWallLeft || isTouchingWallRight;

        // --- Movement ---
        if (Input.GetKey(KeyCode.D))
        {
            if (!startedMoving)
            {
                step = 0;
                lastVelocity = velocity.x;
                startedMoving = true;
                stoppedMoving = false;
            }
            velocity.x = Mathf.Lerp(lastVelocity, speed, step);
            step += accelerationSpeed * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (!startedMoving)
            {
                step = 0;
                lastVelocity = velocity.x;
                startedMoving = true;
                stoppedMoving = false;
            }
            velocity.x = Mathf.Lerp(lastVelocity, -speed, step);
            step += accelerationSpeed * Time.fixedDeltaTime;
        }
        else
        {
            if (!stoppedMoving)
            {
                step = 0;
                lastVelocity = velocity.x;
                stoppedMoving = true;
                startedMoving = false;
            }
            velocity.x = Mathf.Lerp(lastVelocity, 0, step);
            step += stoppingSpeed * Time.fixedDeltaTime;
            step = Mathf.Clamp01(step);
        }

        // --- Wall Slide / Stick ---
        if (isOnWall && !IsGrounded())
        {
            velocity.y = Mathf.Clamp(velocity.y, -wallSlideSpeed, float.MaxValue);

            // --- Climb Up ---
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                velocity.y = climbSpeed;
            }
        }

        // --- Jump ---
        if (Input.GetKey(KeyCode.Space) && isOnWall)
        {
            velocity.y = jumpSpeed;
        }

        rb.velocity = velocity;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spring")
        {
            collision.GetComponent<AudioSource>().Play();
            Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
            velocity.y = 60f;
            Animator animator = collision.GetComponent<Animator>();
            animator.SetTrigger("TouchedPotato");
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);
    }


    
}