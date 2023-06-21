using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalGameManager : MonoBehaviour
{
    private static GlobalGameManager _instance;
    public static string lastLevel;
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
    }
    
    public void QuitApp()
    {
        Application.Quit();
    }
    
    
    public void showDeathMenu()
    {
        SceneManager.LoadScene("Death-menu", LoadSceneMode.Single);
    }

    public void showLevelUpMenu()
    {
        SceneManager.LoadScene("Level-up-menu", LoadSceneMode.Single);
    }

    public void goToNextLevel()
    {
        string[] parts = lastLevel.Split("-");
        int nexLevelNumb = Int32.Parse(parts[1]) + 1;
        string nextLevel = $"Level-{nexLevelNumb}";
        SceneManager.LoadScene(nextLevel);
        PlayerPrefs.DeleteAll();
    }
}
