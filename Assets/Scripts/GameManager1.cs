
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 instance;
    private int blueDiamondsCollected;
    private int redDiamondsCollected;
    [SerializeField]
    private GameObject blueCollectiblePrefab;
    [SerializeField]
    private GameObject redCollectiblePrefab;
    private float timer;  

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {   
        // Clean all the keys storaged 
        // PlayerPrefs.DeleteAll();
        
        // Set to global manager which is the current level
        string currentLevel = SceneManager.GetActiveScene().name;
        GlobalGameManager.lastLevel = currentLevel;
        print(GlobalGameManager.lastLevel);
        
        // Display the collectibles from a json file
        string jsonPathBlue = "Assets/Files/collectibles-lvl1-blue.json";
        string jsonBlue = File.ReadAllText(jsonPathBlue);
        
        string jsonPathRed = "Assets/Files/collectibles-lvl1-red.json";
        string jsonRed = File.ReadAllText(jsonPathRed);
        
        
    }


    private void Update()
    {
        timer += Time.deltaTime;
        // When the players pass the level 1
        if(Door1Collision.valor==1 &&  Door2Collision.valor==1)
        {
            Door1Collision.valor=0;
            Door2Collision.valor=0;
            // Set the level info to show later
            float timeToPassLvl = timer / 60;
            // SceneManager.LoadScene("Level-2");
            PlayerPrefs.SetInt("Level-1-blue-diamonds", blueDiamondsCollected);
            PlayerPrefs.SetInt("Level-1-red-diamonds", redDiamondsCollected);
            PlayerPrefs.SetFloat("Level-1-time", timeToPassLvl);
            GlobalGameManager.Instance.showLevelUpMenu();
        }
    }

    public void collectingBlueDiamonds () => blueDiamondsCollected += 1;
    
    public void collectingRedDiamonds() => redDiamondsCollected += 1;
    
    
}

[System.Serializable]
class Coordinates
{
    public float x;
    public float y;
}
