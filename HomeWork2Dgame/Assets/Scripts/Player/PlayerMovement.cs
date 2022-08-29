using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";

    [SerializeField] private float _speed;
    [SerializeField] private float _forceJump;
    [SerializeField] private AnimatorPlayer _animator;

    private Rigidbody2D _rigidbody;
    private float _horizontalMove = 0f;
    private bool _facingRight = true;
    private float _normalizingFloat = 10f;
        
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxisRaw(Horizontal) * _speed;

        if ( _horizontalMove < 0 && _facingRight)
        {
            Flip();
        }
        else if (_horizontalMove > 0 && !_facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(_horizontalMove * _normalizingFloat, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, _forceJump * Time.deltaTime, 0);
        }
        else
        {
            _animator.EnableIdle();
        }

        if (_rigidbody.velocity.x != 0)
        {
            _animator.Run();
        }
        else
        {
            _animator.EnableIdle();
        }

        if(_rigidbody.velocity.y != 0)
        {
            _animator.Jumping();
        }
    }

    private void Flip()
    {
        int changeDdirection = -1;
        _facingRight = !_facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= changeDdirection;
        transform.localScale = theScale;
    }
}
