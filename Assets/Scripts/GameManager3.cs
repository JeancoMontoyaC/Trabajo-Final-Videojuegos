using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance;

    public GameObject enemy;
    public GameObject enemyClone;
    
    private int blueDiamondsCollected;
    private int redDiamondsCollected;
    [SerializeField]
    private GameObject blueCollectiblePrefab;
    [SerializeField]
    private GameObject redCollectiblePrefab;
    public float timer;
    private string levelDifficulty;
    private int difficultyNum;

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
    
    
    // Start is called before the first frame update
    private void Start()
    {
        levelDifficulty = PlayerPrefs.GetString("Level-3-difficulty", "easy");

        switch (levelDifficulty)
        {
            case "easy":
                difficultyNum = 4;
                break;
            case "medium":
                difficultyNum = 2;
                break;
            case "hard":
                difficultyNum = 1;
                break;
        }
        
        print(difficultyNum);
        // Set to global manager which is the current level
        string currentLevel = SceneManager.GetActiveScene().name;
        GlobalGameManager.lastLevel = currentLevel;
        print(GlobalGameManager.lastLevel);
        
        // Display the collectibles from a json file
        string jsonPathBlue = "Assets/Files/collectibles-lvl3-blue.json";
        string jsonBlue = File.ReadAllText(jsonPathBlue);
        
        string jsonPathRed = "Assets/Files/collectibles-lvl3-red.json";
        string jsonRed = File.ReadAllText(jsonPathRed);
        
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > difficultyNum)
        {
            enemyClone = Instantiate(enemy, new Vector3(Random.Range(-15.0f,15.0f), 8.0f, 0.0f), transform.rotation) as GameObject;
            Destroy(enemyClone, 16);
            timer = 0;
        }
        
        if(Door1Collision.valor==1 &&  Door2Collision.valor==1)
        {
            Door1Collision.valor=0;
            Door2Collision.valor=0;
            // Set the level info to show later
            float timeToPassLvl = timer / 60;
            PlayerPrefs.SetInt("Level-3-blue-diamonds", blueDiamondsCollected);
            PlayerPrefs.SetInt("Level-3-red-diamonds", redDiamondsCollected);
            PlayerPrefs.SetFloat("Level-3-time", timeToPassLvl);
            GlobalGameManager.Instance.showLevelUpMenu();
        }
    }
    
    public void collectingBlueDiamonds ()
    {
        blueDiamondsCollected += 1;
    }

    public void collectingRedDiamonds()
    {
        redDiamondsCollected += 1;
    }
}
