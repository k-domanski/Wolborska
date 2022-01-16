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
    public bool IsActive { get => isActive; set => isActive = value; }
    [SerializeField] protected bool isActive;
    protected ButtonTrigger buttonTrigger;
    
    void Awake()
    {
        buttonTrigger = GetComponent<ButtonTrigger>();
        buttonTrigger.onButtonPressed += Interact;
    }
    public abstract void Interact();
}
