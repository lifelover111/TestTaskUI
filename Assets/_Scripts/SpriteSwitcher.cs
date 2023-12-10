using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpriteSwitcher : MonoBehaviour
{
    [SerializeField] Sprite On;
    [SerializeField] Sprite Off;
    UnityEngine.UI.Image image;
    bool switcher = true;
    private void Awake()
    {
        image = GetComponent<UnityEngine.UI.Image>();
    }

    public void Switch()
    {
        switcher = !switcher;
        if (switcher)
            image.sprite = On;
        else 
            image.sprite = Off;
    }
}
