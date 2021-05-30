using System.Collections;
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
    bool _firstTime;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _firstTime = true;
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
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

        transform.position = Vector3.MoveTowards(transform.position, moveToTarget, speed * Time.deltaTime);
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
