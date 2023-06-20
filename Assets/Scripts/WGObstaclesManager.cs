using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WGObstaclesManager : MonoBehaviour
{
    private bool isDead;
    private string currentLevel;
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Fire"))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            Destroy(gameObject);
            GlobalGameManager.lastLevel = currentLevel;
            print(currentLevel);
            GlobalGameManager.Instance.showDeathMenu();
            isDead = true;
        }
    }
    
}
