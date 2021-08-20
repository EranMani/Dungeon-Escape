using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttackEvent : MonoBehaviour
{
    [SerializeField] GameObject attackPrefab;
    Spider _spider;

    private void Start()
    {
        _spider = transform.parent.GetComponent<Spider>();
    }

    public void Fire()
    {
        _spider.Attack();
    }

    public void StartEffect()
    {
        ParticleSystem effect = Instantiate(attackPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        effect.Play();
    }
}
