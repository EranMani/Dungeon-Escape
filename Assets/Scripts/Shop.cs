using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    int _itemSelected = 0;

    private void Start()
    {
        UIManager.Instance.UpdateShopItemPrices(itemCosts);
    }

    [SerializeField] GameObject shopPanel;
    [SerializeField] int[] itemCosts;
    Player _player;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {           
            if (shopPanel != null)
            {
               shopPanel.SetActive(true);
            }

            Player player = other.GetComponent<Player>();
            if (player)
            {
                _player = player;
                UIManager.Instance.OpenShop(player.diamonds);              
            }
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (shopPanel != null)
            {
                shopPanel.SetActive(false);
            }

        }
    }

    public void Selection(int item)
    {
        _itemSelected = item;
        UIManager.Instance.UpdateShopSelection(item);
    }

    public void BuyItem()
    {
        if (_player.diamonds >= itemCosts[_itemSelected])
        {
            // Check if player buy the key
            if (_itemSelected == 2)
            {
                GameManager.Instance.HasKeyToCastle = true;
            }

            _player.diamonds -= itemCosts[_itemSelected];
            UIManager.Instance.UpdatePlayerCurrentGems(_player.diamonds);
        }
        else
        {
            print("You dont have enough gems!");
        }
    }
}
