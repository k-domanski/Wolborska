using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Goal : AInteractable
{
    #region Properties
    [SerializeField] private PlayableDirector _playableDirector;
    [SerializeField] private Item _item;
    [SerializeField] private Transform placementPoint;
    #endregion

    #region Events
    public static Action onGoalCompleted; 
    #endregion

    #region Messages
    private void OnEnable()
    {
        _item.onItemPickUp += SetGoalActive;
        _playableDirector.stopped += ChangeGameState;
        _playableDirector.stopped += (t) => { onGoalCompleted?.Invoke(); };
    }
    #endregion

    #region Private Methods
    private void SetGoalActive()
    {
        isActive = true;
        buttonTrigger.IsActiveTest = true;
    }
    private void ChangeGameState(PlayableDirector obj)
    {
        GameManager.instance.State = GameState.RUNNING;
    }
    #endregion

    #region Public
    public override void Interact()
    {
        if (!isActive)
        {
            return;
        }

        GameManager.instance.State = GameState.CUTSCENE;
        _playableDirector.Play();
        _item.Place(placementPoint.position);
        isActive = false;
        buttonTrigger.IsActiveTest = false;
    } 
    #endregion
}
