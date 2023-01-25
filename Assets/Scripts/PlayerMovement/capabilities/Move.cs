using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Move : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField, Range(0f, 200f)] private float maxSpeed = 4f;
    [SerializeField, Range(0f, 200f)] private float maxAcceleration = 35f;
    [SerializeField, Range(0f, 200f)] private float maxAirAcceleration = 20f;

    private Controller controller;
    private Vector2 direction, desiredVelocity, velocity;
    private Rigidbody2D body;
    private Ground ground;

    private float maxSpeedChange, acceleration;
    private bool onGround;

    public float moveSpeed;
    float moveInput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ground = GetComponent<Ground>();
        controller = GetComponent<Controller>();
    }

    private void Update()
    {
        //direction.x = controller.input.RetrieveMoveInput();
        //desiredVelocity = new Vector2(direction.x, 0f) * Mathf.Max(maxSpeed - ground.Friction, 0f);
        moveInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(moveInput * moveSpeed, body.velocity.y);
    }

    private void FixedUpdate()
    {
        onGround = ground.OnGround;
        velocity = body.velocity;

        acceleration = onGround ? maxAcceleration : maxAirAcceleration;
        maxSpeedChange = acceleration * Time.deltaTime;
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);

        body.velocity = velocity;
    }
}
