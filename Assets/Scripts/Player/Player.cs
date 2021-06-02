﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] float _movementSpeed = 3f;
    [SerializeField] float _jumpForce = 3f;
    float _horizontalInput;
    float jumpRayLength = 0.2f;
    float _resetJumpTime = 0.15f;
    bool _resetJump;
    bool _isPlayerGrounded;
    public int diamonds;


    Rigidbody2D _rigidBody;
    BoxCollider2D _collider;

    PlayerAnimation _playerAnimation;

    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        diamonds = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetButtonDown("Jump") && _isPlayerGrounded)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            _playerAnimation.JumpPlayer(true);
            StartCoroutine(ResetJumpRoutine());        
        }

        if (Input.GetKeyDown(KeyCode.E) && IsGrounded())
        {
            _playerAnimation.AttackPlayer();
            
        }

        // Debug.DrawRay(transform.position, Vector2.down * .2f, Color.green);
    }

    void Movement()
    {
        _isPlayerGrounded = IsGrounded();

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _rigidBody.velocity = new Vector2(_horizontalInput * _movementSpeed, _rigidBody.velocity.y);

        _playerAnimation.MovePlayer(_horizontalInput);
        _playerAnimation.FlipPlayerSprite(_horizontalInput);
    }

    bool IsGrounded()
    {
        Vector3 originPosition = new Vector3(transform.position.x, _collider.bounds.min.y, transform.position.z);
        
        RaycastHit2D hit = Physics2D.Raycast(originPosition, Vector2.down, jumpRayLength, LayerMask.GetMask("Ground"));
        if (hit &&  !_resetJump)
        {
            _playerAnimation.JumpPlayer(false);
            return true;
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(_resetJumpTime);
        _resetJump = false;
    }

    public void Damage()
    {
        print("Player was attacked!");
    }
}
