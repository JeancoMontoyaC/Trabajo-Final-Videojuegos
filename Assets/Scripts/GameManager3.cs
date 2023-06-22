using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instance;

    public GameObject enemy;
    public GameObject enemyClone;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            enemyClone = Instantiate(enemy, new Vector3(0, 0, 0), transform.rotation) as GameObject;
        }
    }
}
