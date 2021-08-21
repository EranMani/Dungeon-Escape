using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    [SerializeField] GameObject acidPrefab;
    [SerializeField] bool fireAcidRight;
    [SerializeField] Vector3 acidDirection;

    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;

        if (fireAcidRight)
        {
            acidDirection = Vector3.right;
        }
        else
        {
            acidDirection = Vector3.left;
        }

        InvokeRepeating("AttackState", 1f, 1.5f);
    }

    public override void Update()
    {
       
    }

    void AttackState()
    {
        float randValue = UnityEngine.Random.value;
        if (randValue < .3f) // 30% of the time
        {
            anim.SetTrigger("Attack");
        }
        
    }

    public void Damage()
    {
        Health--;
        if (Health <= 0)
        {
            anim.SetTrigger("death");
            SpawnDiamonds();
            Destroy(this.gameObject, 4f);
        }
    }

    public override void Movement()
    {
        // Dont move
    }

    public void Attack()
    {      
        GameObject acid = Instantiate(acidPrefab, transform.position, Quaternion.identity);
        acid.GetComponent<AcidEffect>().SetDirection(acidDirection);     
    }

}
