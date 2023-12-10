using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    ShopItem shopItem;
    [SerializeField] Button buyButton;
    [SerializeField] TMP_Text costText;
    [SerializeField] new TMP_Text name;
    [SerializeField] Image icon;
    [SerializeField] Transform lockIcon;
    [SerializeField] TMP_Text requiredLvl;

    public void SetItem(ShopItem shopItem)
    {
        this.shopItem = shopItem;
        InitItem();
    }

    void InitItem()
    {
        icon.sprite = shopItem.icon;
        name.text = shopItem.name;
        requiredLvl.text = "LVL. " + shopItem.requiredLvl;
        costText.text = shopItem.cost.ToString();
        if(GameManager.instance.GetMaxLevel() < shopItem.requiredLvl)
        {
            icon.gameObject.SetActive(false);
            lockIcon.gameObject.SetActive(true);
            buyButton.interactable = false;
            GameManager.instance.OnLevelPassed += () => {
                if(GameManager.instance.GetMaxLevel() >= shopItem.requiredLvl)
                {
                    icon.gameObject.SetActive(true);
                    lockIcon.gameObject.SetActive(false);
                    buyButton.interactable = true;
                }
            };
        }

        buyButton.onClick.AddListener(GameManager.instance.soundManager.PlayClick);
        buyButton.onClick.AddListener(() => { 
            if(GameManager.instance.TrySpendCurrency(shopItem.cost))
            {
                buyButton.transform.GetChild(0).gameObject.SetActive(false);
                buyButton.transform.GetChild(1).gameObject.SetActive(true);
                buyButton.onClick.RemoveAllListeners();

                PlayerPrefs.SetInt(shopItem.name, 1);
            }
        });

        if(shopItem.bought || PlayerPrefs.GetInt(shopItem.name, 0) == 1)
        {
            buyButton.transform.GetChild(0).gameObject.SetActive(false);
            buyButton.transform.GetChild(1).gameObject.SetActive(true);
            buyButton.onClick.RemoveAllListeners();
        }
    }
}
