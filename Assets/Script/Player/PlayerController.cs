using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed=3f;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();        
    }
    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
        movement = Vector2.ClampMagnitude(movement, moveSpeed);
        rb.velocity = movement;
        animator.SetBool("run", movement.magnitude > 0);
        if (dirX < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (dirX > 0)
        {
            spriteRenderer.flipX = false;
        }        
    }   
}