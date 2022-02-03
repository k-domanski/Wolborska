using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : AInteractable
{
    #region Properties
    [SerializeField] private GameObject _itemModel;
    [SerializeField] private FollowPath indicator;
    #endregion

    #region Events
    public Action onItemPickUp;
    #endregion

    #region Public
    public override void Interact()
    {
        if (!isActive)
        {
            return;
        }

        PickUp();
    }

    public void Place(Vector3 position)
    {
        transform.position = position;
        _itemModel.transform.position = position;
        _itemModel.SetActive(true);
    } 
    #endregion

    #region Private Methods
    private void PickUp()
    {
        isActive = false;
        buttonTrigger.IsActiveTest = false;
        _itemModel.SetActive(false);
        onItemPickUp?.Invoke();
        indicator.CanMove = true;
    } 
    #endregion
}
