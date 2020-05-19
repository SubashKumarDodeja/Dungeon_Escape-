using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text playerGemCountText;
    public Image selectionImg;


    public Text GemcountText;



    public Image[] Healthbar; 



    static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("UIManagererror");

            return _instance;
            
        }
    }

    void Awake()
    {
        _instance = this;
    }


    public void UpdateGemCount(int gemCount)
    {
        GemcountText.text = gemCount.ToString();
    }

    public void openShop(int gemCount)
    {
        playerGemCountText.text = gemCount.ToString() + "G"; 
    }
    


    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos); 
    }

    public void UpdateLifes(int lifeRemaining)
    {
        //Healthbar[Healthbar].enabled = false;
        for (int i= 0;i <= lifeRemaining; i++){
            if (i == lifeRemaining)
            {
                Healthbar[i].enabled = false;
            }
        }
    } 
}

