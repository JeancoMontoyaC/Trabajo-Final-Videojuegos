using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBCollectibleInteraction : MonoBehaviour
{
    private bool isCollected;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("FireBoy"))
        {
            if (!isCollected)
            {
                isCollected = true;
                Destroy(gameObject);
                GameManager1.instance.collectingRedCollectible();
            }
        }
    }
}
