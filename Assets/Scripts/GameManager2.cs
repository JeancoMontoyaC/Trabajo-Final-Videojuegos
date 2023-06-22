using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;

public class GameManager2 : MonoBehaviour
{

    public static GameManager2 instance;
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
        // Set to global manager which is the current level
        string currentLevel = SceneManager.GetActiveScene().name;
        GlobalGameManager.lastLevel = currentLevel;
        print(GlobalGameManager.lastLevel);
        
        // Display the collectibles from a json file
        string jsonPathBlue = "Assets/Files/collectibles-lvl2-blue.json";
        string jsonBlue = File.ReadAllText(jsonPathBlue);
        
        string jsonPathRed = "Assets/Files/collectibles-lvl2-red.json";
        string jsonRed = File.ReadAllText(jsonPathRed);
        
        List<Coordinates> coorListBlue = JsonConvert.DeserializeObject<List<Coordinates>>(jsonBlue);

        foreach (Coordinates coords in coorListBlue)
        {
            Vector3 position = new Vector3(coords.x, coords.y, 0f);
            Instantiate(blueCollectiblePrefab, position, Quaternion.identity);

        }
        
        List<Coordinates> coorListRed = JsonConvert.DeserializeObject<List<Coordinates>>(jsonRed);

        foreach (Coordinates coords in coorListRed)
        {
            Vector3 position = new Vector3(coords.x, coords.y, 0f);
            Instantiate(redCollectiblePrefab, position, Quaternion.identity);
        }
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        
        if(Door1Collision.valor==1 &&  Door2Collision.valor==1)
        {
            Door1Collision.valor=0;
            Door2Collision.valor=0;
            SceneManager.LoadScene("Level-1");
            // Set the level info to show later
            float timeToPassLvl = timer / 60;
            // SceneManager.LoadScene("Level-2");
            PlayerPrefs.SetInt("Level-2-blue-diamonds", blueDiamondsCollected);
            PlayerPrefs.SetInt("Level-2-red-diamonds", redDiamondsCollected);
            PlayerPrefs.SetFloat("Level-2-time", timeToPassLvl);
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


