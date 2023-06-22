using UnityEngine;
using UnityEngine.SceneManagement;

public class FBObstaclesManager : MonoBehaviour
{
    private bool isDead;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Water") || col.CompareTag("Toxic"))
        {
            GlobalGameManager.Instance.showDeathMenu();
            int totalDeaths = PlayerPrefs.GetInt("Level-deaths", 0) + 1;
            PlayerPrefs.SetInt("Level-deaths", totalDeaths);
            Destroy(gameObject);
            isDead = true;
        }
    }
    

}
