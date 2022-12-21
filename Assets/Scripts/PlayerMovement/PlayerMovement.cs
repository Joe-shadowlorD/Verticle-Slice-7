using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movement = 8f;
    private float JumpForce = 20f;
    private float SecondJumpForce = 30f;
    private float sprint = 16f;
    //public float fallingGravityScale = 20;

    private bool candoublejump = false;

    private Rigidbody2D rb;
    public GroundCheck groundCheck;
    public Attack attack;

    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(movement * sprint, 0, 0) * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift) && groundCheck.grounded)
        {
            sprint *= 1.5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprint /= 1.5f;
        }
        if (groundCheck.grounded)
        {
            candoublejump = true;
            anim.SetBool("Jump", false);
            if (Input.GetKeyDown(KeyCode.Z))
            {
                rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
            }
        }
        if (candoublejump)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                rb.AddForce(new Vector2(0, SecondJumpForce), ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
                candoublejump = false;
            }
        }
        else
        {
            anim.SetBool("Jump", false);
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
