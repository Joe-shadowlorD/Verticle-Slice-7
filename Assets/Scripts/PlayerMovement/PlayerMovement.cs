using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movement = 2f;
    private float JumpForce = 7f;
    private float SecondJumpForce = 6f;
    private float speed = 6f;

    private bool candoublejump = false;

    private Rigidbody2D rb;
    public GroundCheck groundCheck;
    public Attack attack;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(movement * speed, 0, 0) * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && groundCheck.grounded)
        {
            speed *= 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 1.5f;
        }
        if (groundCheck.grounded)
        {
            candoublejump = true;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                    rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }
        else if(candoublejump)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                rb.AddForce(new Vector2(0, SecondJumpForce), ForceMode2D.Impulse);
                candoublejump = false;
            }

        }
        if (attack.isattacking)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

}
