using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BonusProgress : MonoBehaviour
{
    [SerializeField] Transform progressBar;
    [SerializeField] TMP_Text progressText;
    [SerializeField] Animation[] checks;
    const int DaysNumber = 7;
    int currentDay;
    public event System.Action OnFullProgress = delegate { };
    
    public void ChangeProgress(int day)
    {
        currentDay = day;
        StartCoroutine(ChangeProgressCoroutine(day));
        if(day == 0)
            foreach(var check in checks)
                check.gameObject.SetActive(false);
        if(day != 6)
        {
            checks[day].gameObject.SetActive(true);
            checks[day].enabled = true;
            checks[day].Play();
        }
    }

    IEnumerator ChangeProgressCoroutine(int day)
    {
        float startTime = Time.time;
        Vector3 current = new Vector3((float)day / DaysNumber, 1, 1);
        Vector3 target = new Vector3((float)(day + 1) / DaysNumber, 1, 1);
        progressBar.localScale = current;
        progressText.text = (day + 1).ToString() + '/' + DaysNumber.ToString();
        while (progressBar.localScale.x < (float)(day + 1) / DaysNumber)
        {
            progressBar.localScale = Vector3.Lerp(current, target, Time.time - startTime);
            yield return null;
        }
        if(progressBar.localScale.x == 1)
            OnFullProgress?.Invoke();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
        progressBar.localScale = new Vector3((float)(currentDay + 1) / DaysNumber, 1, 1);
        progressText.text = (currentDay + 1).ToString() + '/' + DaysNumber.ToString();
    }
}
