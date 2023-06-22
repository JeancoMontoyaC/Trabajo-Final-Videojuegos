using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FBCollectibleInteraction : MonoBehaviour
{
    private bool isCollected;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("FireBoy"))
        {
            if (!isCollected)
            {
                isCollected = true;
                Destroy(gameObject);
                String activeScene = SceneManager.GetActiveScene().name;
                if (activeScene.Equals("Level-1"))
                {
                    GameManager1.instance.collectingRedDiamonds();
                }
                else if (activeScene.Equals("Level-2"))
                {
                    GameManager2.instance.collectingRedDiamonds();
                }
                else
                {
                    GameManager3.instance.collectingRedDiamonds();
                }
            }
        }
    }
}
