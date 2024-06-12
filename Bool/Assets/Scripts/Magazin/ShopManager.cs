using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    [SerializeField] private List<BullShopController> bullShopController;
    [SerializeField] private Bullconomica bullconomica;

    [SerializeField] private Image bullImage;


    private void Start()
    {
        initBullShopList();
    }


    public void buyBuul(int buulId)
    {
        if (!bullShopController[buulId].IsBuy)
        {
            if (bullconomica.minusGold(bullShopController[buulId].price))
            {
                PlayerPrefs.SetInt("BullShop" + buulId, true ? 1 : 0);
                bullShopController[buulId].bullBuy();

                initBullShopList();
            }
        }
        else
        {
            bullImage.color = bullShopController[buulId].BullImage.color;
        }


    }

    private void initBullShopList()
    {
        for (int i = 0; i < bullShopController.Count; i++)
        {
            bullShopController[i].Id = i;
            bullShopController[i].IsBuy = PlayerPrefs.GetInt("BullShop" + i, false ? 1 : 0) == 1;

            bullShopController[i].bullBuy();


        }

        PlayerPrefs.Save();

    }




}
