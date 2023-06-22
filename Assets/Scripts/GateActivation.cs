using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GateActivation : MonoBehaviour
{
    [SerializeField]
    private GameObject gateToActivate;
    
    private bool isActive;

    private int howManyPressingButton;

    private float moveDuration = 10f;

    private float moveDistance = 1f;

    private float pressDistance = 0.2f;

    private Vector3 originalPositionOfGate;
    private Vector3 originalPositionOfButton;

    public void Start()
    {
        originalPositionOfGate = gateToActivate.transform.position;
        originalPositionOfButton = gameObject.transform.position;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.CompareTag("FireBoy") || col.CompareTag("WaterGirl")))
        {
            string buttonType = gameObject.tag;
            
            if (buttonType.Equals("ButtonRight"))
            {
                Gate.buttonRightPressed = true;
            }
            else
            {
                Gate.buttonLeftPressed = true;
            }
            
            if(!Gate.gateIsActive){moveUpGate();}
            Gate.gateIsActive = true;
            pressButtonEffect();
            howManyPressingButton += 1;
            
        }
    }
    

    public void OnTriggerExit2D(Collider2D other)
    {
        string buttonType = gameObject.tag;
        howManyPressingButton -= 1;
        if (buttonType.Equals("ButtonRight"))
        {
            Gate.buttonRightPressed = false;
        }
        else
        {
            Gate.buttonLeftPressed = false;
        }
        
        if (howManyPressingButton < 1 && !(Gate.buttonRightPressed) && !(Gate.buttonLeftPressed))
        {
            moveDownGate();
            Gate.buttonRightPressed = false;
            Gate.buttonLeftPressed = false;
            Gate.gateIsActive = false;
        }
        comeBackButtonEffect();
    }

    public void moveUpGate()
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = gateToActivate.transform.position;
        Vector3 targetPosition = initialPosition + Vector3.up * moveDistance;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            gateToActivate.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
        }
    }

    public void moveDownGate()
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = gateToActivate.transform.position;
        
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            gateToActivate.transform.position = Vector3.Lerp(initialPosition, originalPositionOfGate, t);
        }
    }

    public void pressButtonEffect()
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = gameObject.transform.position;
        Vector3 targetPosition = initialPosition + Vector3.down * pressDistance;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            gameObject.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
        }
    }

    public void comeBackButtonEffect()
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = gameObject.transform.position;
        
        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            gameObject.transform.position = Vector3.Lerp(initialPosition, originalPositionOfButton, t);
        }
    }
    
}
