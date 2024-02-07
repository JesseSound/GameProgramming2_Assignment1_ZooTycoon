using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float speed = 5.0f;
    Rigidbody2D rbody;
    Animator anim;

    // Use this for initialization
    void Start()
    {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


    }

    void FixedUpdate()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Ensure movement is either horizontal or vertical, not diagonal
        if (horizontalInput != 0f)
        {
            verticalInput = 0f;
        }

        Vector2 movement_vector = new Vector2(horizontalInput, verticalInput) * speed * Time.smoothDeltaTime;

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("input_x", 0.0f);
            anim.SetFloat("input_y", 0.0f);
        }
        rbody.MovePosition(rbody.position + movement_vector);
    }
}