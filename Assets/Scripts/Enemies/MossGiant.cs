using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    // Use for initialization
    public override void Init()
    {
        // Call parent function code here instead in parent
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        Health--;
        EnemyHit(Health);
    }

    
}
