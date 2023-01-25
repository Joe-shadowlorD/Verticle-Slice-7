using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField, Range(1f, 50f)]private float moveSpeed;
    float moveInput;

    private Rigidbody2D body;
    private SpriteRenderer spi;
    private Animator anim;
    public bool xflip;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spi = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(moveInput * moveSpeed, body.velocity.y);

        if(body.velocity.x != 0)
        {
            xflip = body.velocity.x < 0;
        }
        anim.SetBool("Walking", body.velocity.x != 0);
        spi.flipX = xflip;
    }
}
