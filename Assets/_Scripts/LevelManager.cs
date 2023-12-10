using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Button[] levels;

    private void Start()
    {
        for (int i = 0; i < levels.Length - 1; i++) 
        {
            int j = i;
            levels[j].onClick.AddListener(() =>
            {
                levels[j + 1].interactable = true;
                levels[j + 1].transform.GetChild(0).gameObject.SetActive(true);
                levels[j + 1].transform.GetChild(1).gameObject.SetActive(false);
                GameManager.instance.PassLevel(j);
            });
        }

        for(int i = 1; i < GameManager.instance.GetMaxLevel() + 1; i++)
        {
            levels[i].interactable = true;
            levels[i].transform.GetChild(0).gameObject.SetActive(true);
            levels[i].transform.GetChild(1).gameObject.SetActive(false);
        }

        AddSounds();
    }

    void AddSounds()
    {
        foreach (var level in levels) 
        {
            level.onClick.AddListener(GameManager.instance.soundManager.PlayClick);
        }
    }
}
