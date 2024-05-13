using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 0.5f;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(horizontalInput * speed , rb.velocity.y);
        rb.velocity = movement;

        // Flip sprite based on movement direction
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Facing left
        }

        animator.SetBool("IsWalking", horizontalInput != 0);
    }
}