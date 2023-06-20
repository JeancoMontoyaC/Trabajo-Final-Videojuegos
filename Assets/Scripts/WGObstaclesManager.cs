using UnityEngine;
using UnityEngine.SceneManagement;

public class WGObstaclesManager : MonoBehaviour
{
    private bool isDead;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Fire"))
        {
            isDead = true;
            Destroy(gameObject);
            showDeathMenu();
        }
    }
    
    public void showDeathMenu()
    {
        SceneManager.LoadScene("Death-menu", LoadSceneMode.Additive);
    }
}
