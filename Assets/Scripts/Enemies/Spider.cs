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
    }

    public override void Update()
    {
        
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
