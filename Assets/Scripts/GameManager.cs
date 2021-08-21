using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image myPanel;
    float fadeTime = 3f;
    [SerializeField] GameObject portalPrefab;
    GameObject player;
    CanvasGroup group;

    public bool HasKeyToCastle { get; set; }
    public bool IsPlayerAlive { get; set; }
    public Player Player { get; private set; }

    public bool IsPortalActive { 
        get
        {
            return portalPrefab.GetComponent<ParticleSystem>().isPlaying;
        }
    }

    private void Awake()
    {
        _instance = this;
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        group = GameObject.Find("HUD").GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        StartCoroutine(FadeAndLoadRoutine());
        player = GameObject.FindGameObjectWithTag("Player");
        group.alpha = 0;
        
    }

    public void ActivatePortalEffect()
    {
        portalPrefab = Instantiate(portalPrefab, player.transform.position, Quaternion.identity);
        portalPrefab.GetComponent<ParticleSystem>().Play();
        player.GetComponentInChildren<Animator>().SetTrigger("Transition_Done");
    }

    private IEnumerator FadeAndLoadRoutine()
    {
        myPanel.CrossFadeAlpha(0f, fadeTime, false);
        yield return new WaitForSeconds(3f);

        ActivatePortalEffect();

        yield return new WaitForSeconds(7f);

        float startTime = 0;
        while (startTime < 1)
        {
            group.alpha = Mathf.Lerp(0f, 1f, startTime);
            startTime += .008f;
            yield return null;
        }
       
        //yield return new WaitForSeconds(4f);
  
        
    }
}
