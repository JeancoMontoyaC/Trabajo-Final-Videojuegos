
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
        string jsonPathBlue = "Assets/Files/collectibles-lvl1-blue.json";
        string jsonBlue = File.ReadAllText(jsonPathBlue);
        
        string jsonPathRed = "Assets/Files/collectibles-lvl1-red.json";
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


    private void Update()
    {
        timer += Time.deltaTime;
        if(Door1Collision.valor==1 &&  Door2Collision.valor==1)
        {
            Door1Collision.valor=0;
            Door2Collision.valor=0;
            SceneManager.LoadScene("Level-2");
            print("Diamantes azules");
            print(blueDiamondsCollected);
            print("Diamantes rojos");
            print(redDiamondsCollected);
            print("Tiempo empleado");
            print(timer/60);
            print("total muertes");
            int deaths = PlayerPrefs.GetInt("Deaths");
            print(deaths);

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

[System.Serializable]
class Coordinates
{
    public float x;
    public float y;
}
