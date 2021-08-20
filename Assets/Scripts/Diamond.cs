using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] GameObject diamondPickupEffectPrefab;
    [SerializeField] float movementSpeed = 3f;
    public int diamondAmount;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim.GetBool("Picked"))
        {
            transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ParticleSystem effect = Instantiate(diamondPickupEffectPrefab, transform.position, transform.rotation).GetComponent<ParticleSystem>();
            effect.Play();
            
            Player player = other.GetComponent<Player>();
            if (player)
            {
                player.AddGems(diamondAmount);
                
                anim.SetBool("Picked", true);
                Destroy(this.gameObject, 2f);
            }
            
        }
    }
}
