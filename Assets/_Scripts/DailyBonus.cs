using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyBonus : MonoBehaviour
{
    [SerializeField] Transform commonView;
    [SerializeField] Transform weeklyAwardView;
    [SerializeField] BonusProgress progress;
    private const string LastClaimedKey = "LastClaimedDate";
    private const string ConsecutiveDaysKey = "ConsecutiveDays";

    public int[] DailyBonusAmount;
    public float ClaimCooldownSeconds = 86400;

    private void Start()
    {
        progress.OnFullProgress += () => {
            commonView.gameObject.SetActive(false);
            weeklyAwardView.gameObject.SetActive(true);
            Animation animation = weeklyAwardView.gameObject.GetComponent<Animation>();
            animation.enabled = true;
        };
    }

    private void OnEnable()
    {
        CheckDailyBonus();
    }

    private void OnDisable()
    {
        commonView.gameObject.SetActive(false);
        weeklyAwardView.gameObject.SetActive(false);
    }

    private void CheckDailyBonus()
    {
        if (CanClaimDailyBonus())
        {
            //Debug.Log("You have a daily bonus available!");
            ClaimDailyBonus();
        }
        else
        {
            //Debug.Log("Bonus already claimed today");
            commonView.gameObject.SetActive(true);
        }
    }

    private bool CanClaimDailyBonus()
    {
        string lastClaimedDateString = PlayerPrefs.GetString(LastClaimedKey, string.Empty);

        if (string.IsNullOrEmpty(lastClaimedDateString))
        {
            return true;
        }
        DateTime lastClaimedDate = DateTime.Parse(lastClaimedDateString);
        return (DateTime.Now - lastClaimedDate).TotalSeconds >= ClaimCooldownSeconds;
    }

    private void ClaimDailyBonus()
    {
        int day = DefineDaysAmount();
        GiveDailyBonus(day);
        PlayerPrefs.SetString(LastClaimedKey, DateTime.Now.ToString());
        PlayerPrefs.SetInt(ConsecutiveDaysKey, day%7);

        //Debug.Log("Daily bonus claimed!");
    }

    

    private void GiveDailyBonus(int day)
    {
        commonView.gameObject.SetActive(true);
        progress.ChangeProgress(day % 7);

        GameManager.instance.GiveCurrency(DailyBonusAmount[day % 7]);
        //Debug.Log(currentBalance);
    }


    int DefineDaysAmount()
    {
        int consecutiveDays = PlayerPrefs.GetInt(ConsecutiveDaysKey, 0);
        string lastClaimedDateString = PlayerPrefs.GetString(LastClaimedKey, string.Empty);
        if (lastClaimedDateString == string.Empty)
            return 0;
        DateTime lastClaimedDate = DateTime.Parse(lastClaimedDateString);
        if ((DateTime.Now - lastClaimedDate).TotalSeconds <= 2 * ClaimCooldownSeconds)
        {
            consecutiveDays++;
        }
        else
        {
            consecutiveDays = 0;
        }
        return consecutiveDays;
    }
}