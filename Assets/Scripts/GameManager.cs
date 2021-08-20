using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is null");
            }

            return _instance;
        }
    }

    [SerializeField] GameObject portalPrefab;
    GameObject player;

    public bool HasKeyToCastle { get; set; }
    public bool IsPlayerAlive { get; set; }

    public bool IsPortalActive { 
        get
        {
            return portalPrefab.GetComponent<ParticleSystem>().isPlaying;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ActivatePortalEffect();
    }

    public void ActivatePortalEffect()
    {
        portalPrefab = Instantiate(portalPrefab, player.transform.position, Quaternion.identity);
        portalPrefab.GetComponent<ParticleSystem>().Play();
    }
}
