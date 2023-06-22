using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WGObstaclesManager : MonoBehaviour
{
    private bool isDead;
    private string currentLevel;
    
    // When the element that triggers the death is a collider
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Fire") || col.CompareTag("Toxic"))
        {
            currentLevel = SceneManager.GetActiveScene().name;
            GlobalGameManager.lastLevel = currentLevel;
            GlobalGameManager.Instance.showDeathMenu();
            int totalDeaths = PlayerPrefs.GetInt("Level-deaths", 0) + 1;
            PlayerPrefs.SetInt("Level-deaths", totalDeaths);
            Destroy(gameObject);
            isDead = true;
        }
    }
    
    // When the element that triggers the death is a rigidBody
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Slime"))
        {
            GlobalGameManager.Instance.showDeathMenu();
            int totalDeaths = PlayerPrefs.GetInt("Level-deaths", 0) + 1;
            PlayerPrefs.SetInt("Level-deaths", totalDeaths);
            Destroy(gameObject);
            isDead = true;
        }
    }
}
