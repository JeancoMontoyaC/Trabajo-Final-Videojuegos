
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
        string ranking = calculateRanking(blueDiamondsNum, redDiamondsNum, levelTimeNum, deathsNum);
        time.text = "Time: " + levelTimeNum + " min.";
        blueDiamonds.text = "Blue Diamonds: " + blueDiamondsNum; 
        redDiamonds.text = "Red Diamonds: " + redDiamondsNum;
        deaths.text = "Ranking: " + ranking;

    }

    private String calculateRanking(int numBlueDiamonds, int numRedDiamonds, float timeUsed, int numDeaths)
    {
        int diamondScore = numBlueDiamonds * 10 + numRedDiamonds * 10;
        float timeScore = 100 - (timeUsed * 20);
        float deathsScore = 100 - numDeaths * 20;
        float totalScore = diamondScore + timeScore + deathsScore;
        
        switch (totalScore)
        {
            case >= 280:
                return Ranking.A1.ToString();
            case  >= 250:
                return Ranking.A2.ToString();
            case  >= 200:
                return Ranking.B1.ToString();
            case  >= 150:
                return Ranking.B2.ToString();
            case  >= 100:
                return Ranking.C1.ToString();
            default:
                return Ranking.C2.ToString();
        }

    }
}

public enum Ranking
{
    C2 ,
    C1,
    B2,
    B1,
    A2,
    A1
}
