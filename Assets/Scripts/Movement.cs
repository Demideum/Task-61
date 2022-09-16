using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Movement : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _position;
    private bool _isGround;
    private float _groundRadius = 0.3f;
    private const string _jump = "Jump";
    private const string _run = "Run";
    private const string _idle = "Idle";

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _isGround = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _groundMask);
        Move();

        if (Input.GetKey(KeyCode.Space) && _isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x * Time.deltaTime, _jumpForce);
        _animator.SetTrigger(_jump);
    }

    private void Move()
    {
        _position.x = Input.GetAxis("Horizontal");
        _spriteRenderer.flipX = _position.x < 0;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetTrigger(_run);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _animator.SetTrigger(_run);
        }
        else
        {
            _animator.SetTrigger(_idle);
        }
    }
}
