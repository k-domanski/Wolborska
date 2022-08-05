using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlacementPoint : AInteract
{
    #region Properties
    [SerializeField] InteractionProxy _interactionManager;
    [SerializeField] private string _itemName;
    [SerializeField] private PlayableDirector _animation;
    #endregion

    #region Private
    private New.Item _item;
    #endregion

    #region Messages
    private void Awake()
    {
        message = "place item";
    }
    private void OnEnable()
    {
        _animation.stopped += ChangeGameState;
    }

    private void OnDisable()
    {
        _animation.stopped -= ChangeGameState;
    }
    #endregion

    #region AInteract
    public override void Interact()
    {
        base.Interact();
        GameManager.instance.State = GameState.CUTSCENE;
        _animation.Play();
        _item = _interactionManager.InteractionManager.GetItem(_itemName);
        _item.Place(transform.position);
    }

    public override bool IsActive()
    {
        return base.IsActive() && _interactionManager.InteractionManager.GetItem(_itemName) != null;
    }
    #endregion


    #region Private Methods
    private void ChangeGameState(PlayableDirector obj)
    {
        GameManager.instance.State = GameState.RUNNING;
    } 
    #endregion
}
