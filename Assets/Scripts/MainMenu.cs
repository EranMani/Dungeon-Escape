using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup transitionText;
    public Image myPanel;
    float fadeTime = 50f;

    public void StartGame()
    {
        StartCoroutine(FadeAndLoadRoutine());
   
    }

    public void QuitApp()
    {
        Application.Quit();
    }
    
    private IEnumerator FadeAndLoadRoutine()
    {
        myPanel.CrossFadeAlpha(255f, fadeTime, false);
        yield return new WaitForSeconds(2f);

        float progress = 0;
        while (transitionText.alpha < 1)
        {
            transitionText.alpha = Mathf.Lerp(0f, 1f, progress);
            progress += 0.01f;
            yield return null;
        }
        
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(1);
    }
}
