using System;
using UnityEngine;

public abstract class AInteract : MonoBehaviour, IInteractable
{
    public string Message => message;
    public bool IsComplete => isComplete;


    protected string message;
    protected bool isComplete;

    public virtual void Interact()
    {
        if (IsComplete)
            return;
    }
}
