using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalGameManager : MonoBehaviour
{
    private static GlobalGameManager _instance;
    public static string lastLevel;
    private int totalDeaths;
    // public static int blueDiamondsCollected;
    // public static int redDiamondsCollected;
    // public static float minutesToPassLevel;
    
    public static GlobalGameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("No GlobalManager exists in scene");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    
    
    public void RetryLevel()
    {
        SceneManager.LoadScene(lastLevel);
        totalDeaths += 1;
        PlayerPrefs.SetInt("Deaths", totalDeaths);
    }
    
    public void QuitApp()
    {
        Application.Quit();
    }
    
    
    public void showDeathMenu()
    {
        SceneManager.LoadScene("Death-menu", LoadSceneMode.Additive);
    }
}
