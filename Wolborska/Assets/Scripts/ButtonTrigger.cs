using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonTrigger : MonoBehaviour
{
    public Action onButtonPressed;
    public Action onTriggerEnter;
    public Action onTriggerExit;

    private bool isInRange = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            onButtonPressed?.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
        onTriggerEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        onTriggerExit?.Invoke();
    }
}
