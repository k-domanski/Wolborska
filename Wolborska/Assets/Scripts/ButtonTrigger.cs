using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonTrigger : MonoBehaviour
{
    #region Properties
    public bool IsActiveTest { get => isActive; set => isActive = value; }
    [SerializeField] private bool isActive = false;
    [SerializeField] private InteractableType type;
    #endregion

    #region Events
    public Action onButtonPressed;
    public Action<InteractableType> onTriggerEnter;
    public Action onTriggerExit;
    #endregion

    #region Private
    private bool isInRange = false;
    #endregion

    #region Messages
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && CanInteract())
        {
            onButtonPressed?.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
        if(isActive)
            onTriggerEnter?.Invoke(type);
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        if(isActive)
            onTriggerExit?.Invoke();
    }
    #endregion

    #region Private Methods
    private bool CanInteract()
    {
        return isActive && isInRange;
    } 
    #endregion
}
