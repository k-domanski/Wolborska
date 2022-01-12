using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Goal : AInteractable
{

    #region Private
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private Item _item;
    #endregion

    #region Messages
    private void OnEnable()
    {
        _item.onItemPickUp += SetGoalActive;
    }
    #endregion
    #region Private Methods
    private void SetGoalActive()
    {
        isActive = true;
        buttonTrigger.IsActiveTest = true;
    }
    #endregion

    #region Public
    public override void Interact()
    {
        if (!isActive)
        {
            return;
        }

        _playableDirector.Play();
        _item.Place(transform.position);
        isActive = false;
        buttonTrigger.IsActiveTest = false;
    } 
    #endregion
}
