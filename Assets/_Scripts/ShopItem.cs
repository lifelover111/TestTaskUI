using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class ShopItem : ScriptableObject
{
    public enum eItemType
    {
        character,
        location
    }
    public eItemType type;
    public new string name;
    public int cost;
    public Sprite icon;
    public bool bought = false;
    public int requiredLvl = 0;
}
