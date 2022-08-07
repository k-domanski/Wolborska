using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionOnTrigger : MonoBehaviour
{
    #region Private
    private Action _action;
    private Collider _collider; 
    #endregion

    #region Messages
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _action();
        }
    }
    #endregion

    #region Public
    public void SetAction(Action action)
    {
        _action = action;
        _collider.enabled = true;
    } 
    #endregion
}
