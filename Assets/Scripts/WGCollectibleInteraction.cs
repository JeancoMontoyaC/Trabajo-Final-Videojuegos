using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WGCollectibleInteraction : MonoBehaviour
{
    private bool isCollected;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("WaterGirl"))
        {
            if (!isCollected)
            {
                isCollected = true;
                Destroy(gameObject);
                String activeScene = SceneManager.GetActiveScene().name;
                if (activeScene.Equals("Level-1"))
                {
                    GameManager1.instance.collectingBlueCollectible();
                }
                else if (activeScene.Equals("Level-2"))
                {
                    GameManager2.instance.collectingBlueCollectible();
                }
                else
                {
                    
                }
            }
        }
    }
}
