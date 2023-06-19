using UnityEngine;
using UnityEngine.SceneManagement;

public class FBObstaclesManager : MonoBehaviour
{
    private bool isDead;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Water"))
        {
            isDead = true;
            Destroy(gameObject);
            resetLevel();
        }
    }
    
    public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Recargando la escena");
        int blueCollected = GameManager1.instance.getBlueCollectiblesCollected();
        print(blueCollected);
    }

}
