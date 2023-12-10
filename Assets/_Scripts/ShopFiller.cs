using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopFiller : MonoBehaviour
{
    [SerializeField] ShopItem[] items;
    [SerializeField] Transform skinsParent;
    [SerializeField] Transform locationsParent;
    [SerializeField] GameObject shopItemPrefab;

    private void Awake()
    {
        foreach (var item in items) 
        {
            GameObject go = Instantiate(shopItemPrefab);
            switch (item.type) 
            {
                case ShopItem.eItemType.character:
                    go.transform.SetParent(skinsParent, false);
                    break;
                case ShopItem.eItemType.location:
                    go.transform.SetParent(locationsParent, false);
                    break;
                default:
                    Destroy(go);
                    break;
            }
            Item i = go.GetComponent<Item>();
            i.SetItem(item);
        }
    }
}
