using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractionManager : MonoBehaviour
{
    #region Private
    private InteractionController _interactionController;
    private List<IInteractable> _interactables = new List<IInteractable>();
    #endregion

    #region Messages
    private void Awake()
    {
        _interactionController = GetComponent<InteractionController>();
    }

    private void OnEnable()
    {
        _interactionController.onActionCompleted += HandleActionCompleted;
    }

    private void OnDisable()
    {
        _interactionController.onActionCompleted -= HandleActionCompleted;
    }
    #endregion

    #region Public
    public Item GetItem(string itemName)
    {
        Item item;
        try
        {
            item = _interactables.OfType<Item>().Where(t => t.ItemName == itemName).FirstOrDefault();
        }
        catch (ArgumentException e)
        {
            return null;
        }
        return item;

    }

    public List<T> GetInteractables<T>() where T : IInteractable
    {
        List<T> list;
        try
        {
            list = _interactables.OfType<T>().ToList();
        }
        catch (ArgumentException e)
        {
            return null;
        }

        return list;
    }
    #endregion

    #region Private Methods
    private void HandleActionCompleted(IInteractable interactable)
    {
        if (interactable == null)
            return;
        _interactables.Add(interactable);
    } 
    #endregion
}
