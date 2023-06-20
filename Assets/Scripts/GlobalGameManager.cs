using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalGameManager : MonoBehaviour
{
    

    public void RetryLevel()
    {
        Debug.Log("Reitentando");
        SceneManager.LoadScene("Level-1");
        // SceneManager.GetActiveScene().buildIndex
    }
    
    public void QuitApp()
    {
        Debug.Log("Saliendo del juego");
        Application.Quit();
    }
}
