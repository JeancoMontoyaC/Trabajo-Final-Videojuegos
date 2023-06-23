using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Collision : MonoBehaviour
{
public static int valor;
void Start(){
valor=0;}

	
	
    

    void Update(){
        
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
