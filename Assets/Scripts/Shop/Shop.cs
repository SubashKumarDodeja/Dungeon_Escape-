using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopPanel;
    public int currentSelectedItem;
    public int currentSelectedItemCost;

    Player _player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player = other.GetComponent<Player>();
            if (_player != null)
            {
                UIManager.Instance.openShop(_player.Daimonds ); 
            }
            ShopPanel.SetActive(true);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ShopPanel.SetActive(false);

        }
    }

    public void selectItem(int item)
    {
        if(item ==0)
        {

            Debug.Log("FlameselectItem");
            UIManager.Instance.UpdateShopSelection(76);
            currentSelectedItem = 0;
            currentSelectedItemCost = 200;
        } else if(item==1)
        {

            UIManager.Instance.UpdateShopSelection(-29);

            currentSelectedItem = 1;

            currentSelectedItemCost = 400;
            Debug.Log("booTselectItem");
        }
        else if(item==2)
        {

            UIManager.Instance.UpdateShopSelection(-123);

            currentSelectedItem = 2;

            currentSelectedItemCost = 100;
            Debug.Log("keYselectItem");
        }
    }

    public void BuyItem()
    {
        if (currentSelectedItemCost <= _player.Daimonds)
        {
            if (currentSelectedItem == 2)
            {
                GameManager.Instance.hasKeyToCastel = true;
            }
            _player.Daimonds -= currentSelectedItemCost;
            ShopPanel.SetActive(false);
        }
        else
        {

            Debug.Log("Not enought Gem");
            ShopPanel.SetActive(false);
        }
    }
}