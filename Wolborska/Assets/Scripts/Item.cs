using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Item : MonoBehaviour, IInteractable
{
    public ButtonTrigger buttonTrigger => _buttonTrigger;
    public bool isPickedUp => _isPickedUp;
    private ButtonTrigger _buttonTrigger;
    private GameObject _itemModel;
    private bool _isPickedUp = false;
    
    public void Interact()
    {
        if(!_isPickedUp)
        {
            Debug.Log("Interakcja");
            PickUp();
        }
        
    }

    public void Place(Vector3 position)
    {
        transform.position = position;
        _itemModel.SetActive(true);
    }
    void Awake()
    {
        _buttonTrigger = GetComponent<ButtonTrigger>();
        _buttonTrigger.onButtonPressed += Interact;
        _itemModel = GetComponentInChildren<Transform>().gameObject;
    }
    
    private void PickUp()
    {
        _isPickedUp = true;
        _itemModel.SetActive(false);
    }
}
