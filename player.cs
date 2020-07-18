using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public  Animator anim;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private bool isMovingLeft;

    private Vector2 moveAmount;
    void Start()
    {
        // anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
        isMovingLeft = false;
    }

    void Update()
    {

        handleInput();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    void handleInput()
    {

        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveAmount = moveInput.normalized * speed;

        // ### UNCOMMENT IF THERE ARE VALUES FOR UP/DOWN ANIMATION ###

        // if (moveInput.y < 0)
        // {
        //     anim.SetBool("isMovingDown", true);
        // }

        // else
        // {
        //     anim.SetBool("isMovingDown", false);
        // }

        // if (moveInput.y > 0)
        // {
        //     anim.SetBool("isMovingUp", true);
        // }

        // else
        // {
        //     anim.SetBool("isMovingUp", false);
        // }

        // ### UP/DOWN MOVMENT ANIMATION ^^^^

        if (moveInput.x > 0 || moveInput.x < 0)
        {

            isMovingLeft = false;

            if (moveInput.x < 0)
            {
                isMovingLeft = true;
            }

            anim.SetBool("isMovingSide", true);
        }

        else
        {
            anim.SetBool("isMovingSide", false);
        }

        shouldFlipX(isMovingLeft);
    }

    void shouldFlipX(bool isMovingLeft)
    {
        if (isMovingLeft)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
