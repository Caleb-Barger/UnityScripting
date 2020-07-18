using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public GameObject weapon;

    private Rigidbody2D rb;
    private bool isMovingLeft;

    private Vector2 moveAmount;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        isMovingLeft = false;
    }

    void Update()
    {
        //  WEPAON ROTATION
        // Vector3 mousePos = Input.mousePosition;
        // mousePos.z = -10;
        // Vector3 objectPosition = Camera.main.WorldToScreenPoint(weapon.transform.position);
        // mousePos.x = mousePos.x - objectPosition.x;
        // mousePos.y = mousePos.y - objectPosition.y;
        // float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        // float restrictedAngle = Mathf.Clamp(angle, -270, 90);
        // weapon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, restrictedAngle));

        moveHandler();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    void moveHandler()
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
        spriteRenderer.flipX = false;

        if (isMovingLeft)
        {
            spriteRenderer.flipX = true;
        }
    }
}
