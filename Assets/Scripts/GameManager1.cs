using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    { 
         if(Door1Collision.valor==1 &&  Door2Collision.valor==1){
            Door1Collision.valor=0;
            Door2Collision.valor=0;
            SceneManager.LoadScene("Level-2");


    }

        
}
}
