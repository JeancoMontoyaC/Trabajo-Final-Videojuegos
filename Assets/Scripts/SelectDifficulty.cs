using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectDifficulty : MonoBehaviour
{
    
    public void DropDownSample(int index)
    {
        print("Dropdown change");
        
        switch (index)
        {
            case 0:
                PlayerPrefs.SetString("Level-3-difficulty", "easy");
                break;
            case 1:
                PlayerPrefs.SetString("Level-3-difficulty", "medium");
                break;
            case 2: 
                PlayerPrefs.SetString("Level-3-difficulty", "hard");
                break;
        }
    }

    
}