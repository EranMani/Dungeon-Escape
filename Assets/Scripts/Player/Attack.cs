using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject hitImpactEffectPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        ParticleSystem effect = Instantiate(hitImpactEffectPrefab, other.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        effect.Play();
        //Destroy(effect, 1f);
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.Damage();
        }
    }
}
