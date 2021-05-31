﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// virtual allows to rewrite implementation of a function
// override allows to override the existing data plus adding additional code

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform pointA, pointB;

    protected Animator anim;
    protected SpriteRenderer spriteRenderer;
    protected Vector3 moveToTarget;
    protected bool isHit = false;

    protected GameObject player;

    bool _firstTime;
    bool _isDead;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.Find("Player");
        _firstTime = true;
        transform.position = pointA.position;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (_isDead) { return; }
        if (AnimatorIsPlaying("idle"))
        {
            return;
        }

        Movement();
    }

    public virtual void Movement()
    {
        FlipSprite();

        if (transform.position == pointA.position)
        {
            moveToTarget = pointB.position;
            if (!_firstTime)
            {
                anim.SetTrigger("StopWalk");
            }
        }
        else if (transform.position == pointB.position)
        {
            moveToTarget = pointA.position;
            anim.SetTrigger("StopWalk");
            if (_firstTime)
            {
                _firstTime = false;
            }
        }

        if (!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToTarget, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, player.transform.position) > 2f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
            anim.Play("walk");
        }     
    }

    public virtual void EnemyHit(int health)
    { 
        anim.SetTrigger("Hit");
        anim.SetBool("InCombat", true);
        isHit = true;

        if (health <= 0)
        {
            _isDead = true;
            anim.SetTrigger("death");
            Destroy(this.gameObject, 4f);
        }
    }

    bool AnimatorIsPlaying(string stateName)
    {
        return AnimatorIsPlaying() && anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    bool AnimatorIsPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length >
               anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    void FlipSprite()
    {     
        if (anim.GetBool("InCombat"))
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();

            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if(direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            if (moveToTarget == pointB.position)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }

        
    }

}