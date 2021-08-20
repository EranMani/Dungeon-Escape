using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiantWalkEffect : MonoBehaviour
{
    [SerializeField] GameObject walkImpactEffectPrefab;
    [SerializeField] Transform effectPos;

    public void WalkEffect()
    {
        ParticleSystem effect = Instantiate(walkImpactEffectPrefab, effectPos.position, Quaternion.Euler(83,0,0)).GetComponent<ParticleSystem>();
        effect.Play();
    }
}
