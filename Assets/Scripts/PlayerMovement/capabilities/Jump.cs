using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Jump : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(100f, 200f)] private float jumpHeight = 3f;
    [SerializeField, Range(0, 5)] private int maxAirJumps = 0;
    [SerializeField, Range(10f, 20f)] private float downwardMovementMultiplier = 3f;
    [SerializeField, Range(10f, 20f)] private float upwardMovementMultiplier = 1.7f;

    private Controller controller;
    private Rigidbody2D body;
    private Ground ground;
    private Animator anim;
    private Attack attack;

    private Vector2 velocity;

    private int jumpPhase;
    private float defaultGravityScale, jumpSpeed;

    private bool desiredJump, onGround;


    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        controller = GetComponent<Controller>();
        anim = GetComponentInChildren<Animator>();
        attack = GetComponent<Attack>();

        defaultGravityScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        desiredJump |= controller.input.RetrieveJumpInput();
    }

    private void FixedUpdate()
    {
        onGround = ground.OnGround;
        anim.SetBool("InAir", !onGround);
        velocity = body.velocity;

        if (onGround)
        {
            jumpPhase = 0;
        }

        if (desiredJump)
        {
            desiredJump = false;
            JumpAction();
        }

        if (body.velocity.y > 0)
        {
            body.gravityScale = upwardMovementMultiplier;
        }
        else if (body.velocity.y < 0)
        {
            body.gravityScale = downwardMovementMultiplier;
        }
        else if (body.velocity.y == 0)
        {
            body.gravityScale = defaultGravityScale;
        }

        if (!attack.isattacking)
        {
            body.velocity = velocity;
        }
        else
        {
            body.velocity = new Vector2(body.velocity.x/2, 0);
        }
        anim.SetInteger("Jump", jumpPhase);
    }
    private void JumpAction()
    {
        if (onGround || jumpPhase < maxAirJumps)
        {
            jumpPhase += 1;

            jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);

            if (velocity.y > 0f)
            {
                jumpSpeed = Mathf.Max(jumpSpeed - velocity.y, 0f);
            }
            else if (velocity.y < 0f)
            {
                jumpSpeed += Mathf.Abs(body.velocity.y);
            }
            velocity.y += jumpSpeed;
        }
    }
}

