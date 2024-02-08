using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 5f;
    Rigidbody2D rb;
    Vector2 velocity;
    Animator animator;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    private float lastMovementX;
    private float lastMovementY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        // Check if player movement is zero and the last movement was positive in the X direction
        if (horizontalInput == 0 && lastMovementX > 0)
        {
            SetSprite(rightSprite);
        }

        // Check if player movement is zero and the last movement was positive in the Y direction
        if (verticalInput == 0 && lastMovementY > 0)
        {
            SetSprite(upSprite);
        }

        // Update last movement values for the next frame
        lastMovementX = horizontalInput;
        lastMovementY = verticalInput;
    }

    private void SetSprite(Sprite newSprite)
    {
        // Assuming you have a SpriteRenderer component attached to your GameObject
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer component not found on the GameObject.");
        }
    }

    private void FixedUpdate()
    {
        // Move the player rigidbody
        rb.MovePosition(rb.position + velocity * moveSpeed * Time.fixedDeltaTime);
    }
}
