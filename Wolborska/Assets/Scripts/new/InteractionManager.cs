using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InteractionManager : MonoBehaviour
{
    private InteractionController _interactionController;
    private List<IInteractable> _interactables = new List<IInteractable>();
    
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

    public New.Item GetItem(string itemName)
    {
        New.Item item;
        try
        {
            item = _interactables.OfType<New.Item>().Where(t => t.ItemName == itemName).FirstOrDefault();
        }
        catch (ArgumentException e)
        {
            return null;
        }
        return item;

    }

    public List<T> GetInteractables<T> () where T : IInteractable
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

    private void HandleActionCompleted(IInteractable interactable)
    {
        if (interactable == null)
            return;
        _interactables.Add(interactable);
    }
}
