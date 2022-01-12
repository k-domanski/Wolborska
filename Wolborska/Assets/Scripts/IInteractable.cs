using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType
{
    PICKUP,
    GOAL,
    DOOR
}
public interface IInteractable
{
    public InteractableType type { get; }
    public void Interact();
}
