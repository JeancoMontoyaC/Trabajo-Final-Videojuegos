using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json;

public class GameManager2 : MonoBehaviour
{

    public static GameManager2 instance;
    private int blueCollectiblesCollected;
    private int redCollectiblesCollected;
    [SerializeField]
    private GameObject blueCollectiblePrefab;
    [SerializeField]
    private GameObject redCollectiblePrefab;
    
    
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
        if(Door1Collision.valor==1 &&  Door2Collision.valor==1){
            Door1Collision.valor=0;
            Door2Collision.valor=0;
            SceneManager.LoadScene("Level-1");
         }
    }
    
    public void collectingBlueCollectible ()
    {
        blueCollectiblesCollected += 1;
    }

    public void collectingRedCollectible()
    {
        redCollectiblesCollected += 1;
    }
}


