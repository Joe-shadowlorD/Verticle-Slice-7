using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField, Range(1f, 50f)]private float moveSpeed;
    float moveInput;

    private Rigidbody2D body;
    private SpriteRenderer spi;
    public Animator animator;
    public bool xflip;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spi = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(moveInput * moveSpeed, body.velocity.y);
        if (body.velocity.x != 0)
        {
            xflip = body.velocity.x < 0;
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
        spi.flipX = xflip;
    }
}
