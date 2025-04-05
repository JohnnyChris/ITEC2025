using UnityEngine;

public class LeafMovement : MonoBehaviour
{
    private int direction = 1;
    public int speed = 15;
    public LayerMask limitLayer;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, Vector2.left * 0.8f, Color.red);
        //Debug.DrawRay(transform.position, Vector2.right * 0.8f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.left, 0.8f, limitLayer))
        {
            direction = 1;
        }
        if (Physics2D.Raycast(transform.position, Vector2.right, 0.8f, limitLayer))
        {
            direction = -1;
        }

        rb.velocity = new Vector2(speed * direction, 0);

    }
}