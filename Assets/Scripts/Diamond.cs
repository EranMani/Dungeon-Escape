using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int diamondAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                player.diamonds += diamondAmount;
                Destroy(this.gameObject);
            }
            
        }
    }
}
