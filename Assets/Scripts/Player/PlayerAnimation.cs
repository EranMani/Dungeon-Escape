using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _anim;
    Animator _swordAnim;
    SpriteRenderer _spriteRenderer;
    SpriteRenderer _swordSpriteRenderer;

    void Start()
    {
        _anim = gameObject.transform.GetChild(0).GetComponent<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _swordAnim = GameObject.Find("Sword_Effect").GetComponent<Animator>();
        _swordSpriteRenderer = GameObject.Find("Sword_Effect").GetComponent<SpriteRenderer>();
    }

    public void MovePlayer(float moveAmount)
    {
        _anim.SetFloat("Move", Mathf.Abs(moveAmount));
    }

    public void JumpPlayer(bool canJump)
    {
        _anim.SetBool("Jump", canJump);
    }

    public void FlipPlayerSprite(float moveDirection)
    {
        if (moveDirection > 0)
        {
            _spriteRenderer.flipX = false;
            _swordSpriteRenderer.flipX = true;
        }
        else if (moveDirection < 0)
        {
            _spriteRenderer.flipX = true;
            _swordSpriteRenderer.flipX = false;
        }
    }

    public void AttackPlayer()
    {
        _anim.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordEffect");
    }

    public void PlayerDie()
    {
       _anim.SetTrigger("Death");
    }

    public void PlayerHit()
    {
        _anim.SetTrigger("Hit");
    }

    public Animator GetAnim()
    {
        return _anim;
    }
}
