using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private float life_time=5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,life_time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
