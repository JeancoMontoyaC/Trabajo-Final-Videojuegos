
using System;
using TMPro;
using UnityEngine;

public class LevelUpMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI blueDiamonds;
    [SerializeField] private TextMeshProUGUI redDiamonds;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private TextMeshProUGUI deaths;

    private void Start()
    {
        string currentLevel =  GlobalGameManager.lastLevel;
        string[] parts = currentLevel.Split("-");
        int levelNum = Int32.Parse(parts[1]);
        string blueDiamondsKey = $"Level-{levelNum}-blue-diamonds";
        string redDiamondsKey = $"Level-{levelNum}-red-diamonds";
        string levelTimeKey = $"Level-{levelNum}-time";
        string deathsKey = $"Level-deaths";
        
        int blueDiamondsNum = PlayerPrefs.GetInt(blueDiamondsKey);
        int redDiamondsNum = PlayerPrefs.GetInt(redDiamondsKey);
        float levelTimeNum = PlayerPrefs.GetFloat(levelTimeKey);
        int deathsNum = PlayerPrefs.GetInt(deathsKey);

        time.text = "Time: " + levelTimeNum;
        blueDiamonds.text = "Blue Diamonds: " + blueDiamondsNum; 
        redDiamonds.text = "Red Diamonds: " + redDiamondsNum;
        deaths.text = "Deaths: " + deathsNum;
        
    }
}
