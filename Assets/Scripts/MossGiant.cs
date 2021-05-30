using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    // Use for initialization
    public override void Init()
    {
        // Call parent function code here instead in parent
        base.Init();
        gems = 5;
    }
}
