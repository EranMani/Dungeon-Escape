using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] float _movementSpeed = 3f;
    [SerializeField] float _jumpForce = 3f;
    [SerializeField] Transform stonesEffectPoint;
    [SerializeField] ParticleSystem groundEffect;

    float _horizontalInput;
    float jumpRayLength = 0.2f;
    float _resetJumpTime = 0.15f;
    bool _resetJump;
    bool _isPlayerGrounded;
    public int diamonds;

    Rigidbody2D _rigidBody;
    BoxCollider2D _collider;
    FixedJoystick _joystickHandle;
    SpriteRenderer _sprite;

    PlayerAnimation _playerAnimation;

    public int Health { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _joystickHandle = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        diamonds = 0;
        Health = 4;

        GameManager.Instance.IsPlayerAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsPortalActive) { return; }
        if (!GameManager.Instance.IsPlayerAlive) { return; }

        Movement();
        GroundLandEffect();
        // Debug.DrawRay(transform.position, Vector2.down * .2f, Color.green);
    }

    private void GroundLandEffect()
    {
        if (_playerAnimation.GetAnim().GetCurrentAnimatorStateInfo(0).IsName("Player_Jump"))
        {
            print(_playerAnimation.GetAnim().GetCurrentAnimatorStateInfo(0).normalizedTime);
            if (_playerAnimation.GetAnim().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.5 && IsGrounded())
            {
                ParticleSystem stones = Instantiate(groundEffect, stonesEffectPoint.transform.position, Quaternion.identity);
                stones.Play();
                Destroy(stones, 1f);
            }
        }
    }

    void Movement()
    {
        _isPlayerGrounded = IsGrounded();

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        //_horizontalInput = _joystickHandle.Horizontal;
        //print(_rigidBody.velocity.y);
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
        print("Attacked!");
        Health--;
        UIManager.Instance.RemoveLife(Health);

        if (Health <= 0)
        {
            GameManager.Instance.IsPlayerAlive = false;
            _playerAnimation.PlayerDie();
        }
    }

    public void AddGems(int gemsAmount)
    {
        diamonds += gemsAmount;
        UIManager.Instance.UpdateGemCount(diamonds);
    }

    public void JumpPress()
    {
        if (_isPlayerGrounded)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            _playerAnimation.JumpPlayer(true);
            StartCoroutine(ResetJumpRoutine());
        }       
    }

    public void AttackPress()
    {
        if (IsGrounded())
        {
            _playerAnimation.AttackPlayer();
        }
    }
}
