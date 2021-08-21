using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathGroundEffect : MonoBehaviour
{
    [SerializeField] GameObject groundImpactEffectPrefab;
    [SerializeField] Transform leftFall;
    [SerializeField] Transform rightFall;
    Transform effectPos;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void ActivateEffect()
    {
        Vector3 enemyDirectionLocal = player.transform.InverseTransformPoint(transform.position);
        print(enemyDirectionLocal);
        if (enemyDirectionLocal.x < 0)
        {
            effectPos = rightFall;
            Debug.Log("RIGHT");
        }
        else if (enemyDirectionLocal.x > 0)
        {
            effectPos = leftFall;
            Debug.Log("LEFT");
        }

        ParticleSystem effect = Instantiate(groundImpactEffectPrefab, effectPos.position, Quaternion.identity).GetComponent<ParticleSystem>();
        effect.Play();
    }
}
