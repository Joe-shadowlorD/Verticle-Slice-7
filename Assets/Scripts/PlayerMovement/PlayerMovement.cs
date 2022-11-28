using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movement = 2f;
    private float JumpForce = 7f;
    private float SecondJumpForce = 6f;
    private float speed = 6f;

    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.05f;
    [SerializeField] private LayerMask _collisionMask;

    [Header("Dashing")]
    [SerializeField] private float _dashingVelocity = 14f;
    [SerializeField] private float _dashingTime = 0.5f;
    private Vector2 _dashingDir;
    private bool _isDashing;
    private bool _canDash = true;

    private bool candoublejump = false;

    private Rigidbody2D rb;
    private TrailRenderer _trailRenderer;
    public GroundCheck groundCheck;

    private void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(movement * speed, 0, 0) * Time.deltaTime);

        var dashInput = Input.GetButtonDown("Dash");

        if(dashInput && _canDash)
        {
            _isDashing = true;
            _canDash = false;
            _trailRenderer.emitting = true;
            _dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if(_dashingDir == Vector2.zero)
            {
                _dashingDir = new Vector2(transform.localScale.x, 0);
            }
            StartCoroutine(stopDashing());
        }

        

        if (_isDashing)
        {
            rb.velocity = _dashingDir.normalized * _dashingVelocity;
            return;
        }
        if (isGrounded())
        {
            _canDash = true;
        }

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

    }
    
    private IEnumerator stopDashing()
    {
        yield return new WaitForSeconds(_dashingTime);
        _trailRenderer.emitting = false;
        _isDashing = false;
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle( _groundCheck.position, _groundCheckRadius, _collisionMask);
    } 
}
