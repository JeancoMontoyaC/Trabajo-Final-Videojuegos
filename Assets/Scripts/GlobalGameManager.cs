using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalGameManager : MonoBehaviour
{
    private static GlobalGameManager _instance;
    public static string lastLevel;
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
        // SceneManager.GetActiveScene().buildIndex
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
