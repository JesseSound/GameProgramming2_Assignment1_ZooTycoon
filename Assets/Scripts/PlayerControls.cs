using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    Vector2 velocity;
    Animator animator;
    SpriteRenderer spriteRenderer;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get horizontal and vertical inputs
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Check if only horizontal or vertical input is present
        if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
        {
            velocity.x = horizontalInput;
            velocity.y = 0f;
        }
        else
        {
            velocity.x = 0f;
            velocity.y = verticalInput;
        }

        // Update animator parameters
        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);
        animator.SetFloat("speed", velocity.sqrMagnitude);

        // Update sprite based on the last movement direction
        UpdateSpriteDirection();
    }

    private void FixedUpdate()
    {
        // Move the player rigidbody
        rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);
    }

    void UpdateSpriteDirection()
    {
        if (velocity.x != 0f || velocity.y != 0f)
        {
            // Set the sprite based on the last non-zero movement direction
            if (velocity.x < 0f)
                spriteRenderer.sprite = leftSprite;
            else if (velocity.x > 0f)
                spriteRenderer.sprite = rightSprite;
            else if (velocity.y < 0f)
                spriteRenderer.sprite = downSprite;
            else if (velocity.y > 0f)
                spriteRenderer.sprite = upSprite;
        }
    }
}
