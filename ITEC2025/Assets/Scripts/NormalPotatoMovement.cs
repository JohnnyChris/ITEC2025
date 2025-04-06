using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPotatoMovement : MonoBehaviour
{
    public float speed = 5f;
    public float stoppingSpeed= 0.5f;
    public float accelerationSpeed =1f;
    public float jumpSpeed = 3f;
    private Rigidbody2D rb;

    private float lastVelocity;
    float step;
    private bool stoppedMoving;
    private bool startedMoving;
    public LayerMask groundLayer;
    public LayerMask wall;
    public LayerMask fry;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
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
        else if (Input.GetKey(KeyCode.D) && !Physics2D.Raycast(transform.position, Vector2.right, 2f, wall))
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
        else if (Input.GetKey(KeyCode.A) && !Physics2D.Raycast(transform.position, Vector2.left, 2f, wall))
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
        
        if (Input.GetKey(KeyCode.Space) && (Physics2D.Raycast(transform.position, Vector2.down, 1.2f, groundLayer) || Physics2D.Raycast(transform.position, Vector2.down, 1.2f, fry)))
        {
            velocity.y = jumpSpeed;
        }

        rb.velocity = velocity;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "spring")
        {
            Vector2 velocity = rb.velocity;
            velocity.y = jumpSpeed * 1.5f;
            Animator animator = collision.GetComponent<Animator>();
            animator.SetTrigger("TouchedPotato");
            rb.velocity = velocity;
        }
    }

    public void DestroyPotato()
    {
        Destroy(gameObject);
    }
}
