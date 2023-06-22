using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MusicLevel1 : MonoBehaviour
{

    public GameObject sound1;
    
    public GameObject sound2;

    private GameObject o;
    
    
    void Start()
    {	int randomNumber = Mathf.FloorToInt(Random.Range(1f, 3f));
	if(randomNumber==1){
		o=Instantiate(sound1);
	}
	else{
		o=Instantiate(sound2);
    	}
	
	
    }
   
     private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Destroy(o);
            o=Instantiate(sound1); // Instanciar el segundo objeto
        }

        if (Input.GetMouseButtonDown(1))
        {
            
            Destroy(o);
            o=Instantiate(sound2);
        }
    }

   
}