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
        if (timer > 2)
        {
            enemyClone = Instantiate(enemy, new Vector3(Random.Range(-15.0f,15.0f), 8.0f, 0.0f), transform.rotation) as GameObject;
            Destroy(enemyClone, 5);
            timer = 0;
        }
    }
}
