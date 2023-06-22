using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanVariables : MonoBehaviour
{
    public static int timesRendered;
    void Start()
    {
        if (timesRendered == 0)
        {
            PlayerPrefs.DeleteAll();
        }

        timesRendered += 1;
        print(timesRendered);
    }

}
