using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] TMP_Text currencyCounter;
    public event System.Action OnLevelPassed = delegate { };
    [SerializeField] bool clearAllData = false;
    public SoundManager soundManager;

    int currency;
    int maxLevel;

    private void Awake()
    {
        instance = this;

        soundManager = GetComponent<SoundManager>();

        if (clearAllData)
            PlayerPrefs.DeleteAll();

        currency = PlayerPrefs.GetInt("PlayerBalance", 0);
        currencyCounter.text = currency.ToString();
        maxLevel = PlayerPrefs.GetInt("Level", 0);
    }

    public bool TrySpendCurrency(int currencyCount)
    {
        if (currencyCount > currency)
            return false;
        currency -= currencyCount;
        UpdateCurrency();
        return true;
    }

    public void GiveCurrency(int currencyCount)
    {
        currency += currencyCount;
        UpdateCurrency();
    }

    void UpdateCurrency()
    {
        PlayerPrefs.SetInt("PlayerBalance", currency);
        currencyCounter.text = currency.ToString();
    }

    public void PassLevel(int level)
    {
        if (level + 1 < maxLevel)
            return;
        maxLevel = level + 1;
        PlayerPrefs.SetInt("Level", maxLevel);
        OnLevelPassed?.Invoke();
    }
    public int GetMaxLevel()
    {
        return maxLevel;
    }
}
