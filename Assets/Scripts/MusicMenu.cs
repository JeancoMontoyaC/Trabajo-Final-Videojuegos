using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    public GameObject sound;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(sound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
