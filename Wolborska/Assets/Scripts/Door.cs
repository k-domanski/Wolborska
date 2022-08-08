using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class Door : AInteract
{
    #region Private
    private PlayableDirector _animation;
    #endregion

    #region Messages
    private void Awake()
    {
        message = "open the door";
        _animation = GetComponent<PlayableDirector>();
        GetComponent<Collider>().enabled = false;
    }

    private void OnEnable()
    {
        _animation.stopped += HandleAnimationEnding;
    }

    private void OnDisable()
    {
        _animation.stopped -= HandleAnimationEnding;
    }
    #endregion

    #region AInteract
    public override void Interact()
    {
        base.Interact();
        GameManager.instance.State = GameState.CUTSCENE;
        _animation.Play();
    }

    public override bool IsActive()
    {
        return base.IsActive();
    }
    #endregion

    #region Public
    public void Activate()
    {
        GetComponent<Collider>().enabled = true;
    }
    #endregion

    #region Private Methods
    private void HandleAnimationEnding(PlayableDirector obj)
    {
        GameManager.instance.State = GameState.RUNNING;
        Application.Quit();
    } 
    #endregion
}
