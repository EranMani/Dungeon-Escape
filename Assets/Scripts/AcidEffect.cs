using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 3f;
    [SerializeField] GameObject hitImpactEffectPrefab;

    private void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right *_moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ParticleSystem effect = Instantiate(hitImpactEffectPrefab, other.transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            effect.Play();

            IDamageable hit = other.GetComponent<IDamageable>();
            if (hit != null)
            {
                hit.Damage();
                Destroy(this.gameObject);
            }
        }
        
    }
}
