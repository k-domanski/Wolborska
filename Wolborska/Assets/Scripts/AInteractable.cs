using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType
{
    PICKUP,
    GOAL,
    DOOR
}

public abstract class AInteractable : MonoBehaviour
{
    #region Properties
    public bool IsActive { get => isActive; set => isActive = value; }
    [SerializeField] protected bool isActive;
    #endregion


    #region Protected
    protected ButtonTrigger buttonTrigger;
    #endregion


    #region Messages
    void Awake()
    {
        buttonTrigger = GetComponent<ButtonTrigger>();
        buttonTrigger.onButtonPressed += Interact;
    }
    #endregion

    #region Public
    public abstract void Interact(); 
    #endregion
}
