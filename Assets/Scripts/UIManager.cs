using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is null!");
            }

            return _instance;
        }
    }

    [SerializeField] Text playerGemCountText;
    [SerializeField] GameObject[] selectionImage;
    [SerializeField] Text[] prices;

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = gemCount + "G";
    }

    public void UpdatePlayerCurrentGems(int currentGems)
    {
        playerGemCountText.text = currentGems + "G";
    }

    public void UpdateShopSelection(int item)
    {
        foreach (GameObject selection in selectionImage)
        {
            selection.SetActive(false);
        }

        selectionImage[item].SetActive(true);
    }

    public void UpdateShopItemPrices(int[] costs)
    {
        for (int i = 0; i < prices.Length; i++)
        {
            prices[i].text = costs[i] + "G";
        }
    }

    private void Awake()
    {
        _instance = this;
    }
}
