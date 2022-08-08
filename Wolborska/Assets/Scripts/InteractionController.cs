using System;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    #region Events
    public Action<bool, string> onActionInRange;
    public Action<IInteractable> onActionCompleted;
    #endregion

    #region Private
    private IInteractable _interactable;
    #endregion

    #region Messages
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _interactable != null && _interactable.IsActive())
        {
            _interactable.Interact();
            onActionCompleted?.Invoke(_interactable);
            onActionInRange?.Invoke(false, null);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out _interactable) && _interactable.IsActive())
        {
            onActionInRange?.Invoke(true, _interactable.Message);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IInteractable>(out _interactable))
        {
            onActionInRange?.Invoke(false, _interactable.Message);
            _interactable = null;
        }
    } 
    #endregion

}
