using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;

public class WindowController : MonoBehaviour
{
    [SerializeField] Animator menuView;
    [SerializeField] Animator settingsView;
    [SerializeField] Animator dailyBonusView;
    [SerializeField] Animator levelsView;
    [SerializeField] Animator shopView;

    public void Play()
    {
        menuView.SetBool("open", false);
        levelsView.gameObject.SetActive(true);
        levelsView.SetBool("open", true);
    }

    public void GoSettings()
    {
        settingsView.gameObject.SetActive(true);
        settingsView.SetBool("open", true);
    }

    public void GoDailyBonusMenu()
    {
        dailyBonusView.gameObject.SetActive(true);
        dailyBonusView.SetBool("open", true);
    }

    public void GoShop()
    {
        menuView.SetBool("open", false);
        shopView.gameObject.SetActive(true);
        shopView.SetBool("open", true);
    }
    public void GoMenu()
    {
        if(settingsView.gameObject.activeInHierarchy)
            settingsView.SetBool("open", false);
        if (dailyBonusView.gameObject.activeInHierarchy)
            dailyBonusView.SetBool("open", false);
        if (levelsView.gameObject.activeInHierarchy)
            levelsView.SetBool("open", false);
        if(shopView.gameObject.activeInHierarchy)
            shopView.SetBool("open", false);

        menuView.gameObject.SetActive(true);
        menuView.SetBool("open", true);
    }
}
