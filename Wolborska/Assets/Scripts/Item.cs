using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : AInteractable
{
    public Action onItemPickUp;
    [SerializeField] private GameObject _itemModel;

    public override void Interact() 
    {
        if(!isActive)
        {
            return;
        }

        PickUp();
    }

    public void Place(Vector3 position)
    {
        transform.position = position;
        _itemModel.SetActive(true);
    }
    private void PickUp()
    {
        isActive = false;
        buttonTrigger.IsActiveTest = false;
        _itemModel.SetActive(false);
        onItemPickUp?.Invoke();
    }
}
