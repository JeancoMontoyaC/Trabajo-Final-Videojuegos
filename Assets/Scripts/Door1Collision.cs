using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Collision : MonoBehaviour
{
    public static int valor=0;

       void Update(){
        Debug.Log(valor);
    }
    void OnTriggerEnter2D(){
        valor=1;
        Debug.Log("Entro en colision");
    }

    void OnTriggerExit2D(){
        valor=0;
        Debug.Log("Salgo");
    }
   
}
