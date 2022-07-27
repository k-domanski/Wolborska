using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour
{

    public Action<bool, string> onActionRange;
    void OnTriggerEnter(Collider other)
    {
        IInteractable item;
        if (other.TryGetComponent<IInteractable>(out item))
        {
            onActionRange?.Invoke(!item.IsComplete, item.Message);
            item.Interact();
        }
    }

    void OnTriggerExit(Collider other)
    {
        IInteractable item;
        if (other.TryGetComponent<IInteractable>(out item))
        {
            onActionRange?.Invoke(!item.IsComplete, item.Message);
            Debug.Log("Trigger Exit");
        }
    }


}
