using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Collision : MonoBehaviour
{
    public static int valor=0;

       void Update(){

    }
    void OnTriggerEnter2D(){
        valor=1;
    }

    void OnTriggerExit2D(){
        valor=0;
    }
   
}
