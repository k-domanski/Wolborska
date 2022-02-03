using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class Door : AInteractable
{
    #region Properties
    [SerializeField] private PlayableDirector director;
    #endregion

    #region Public
    public override void Interact()
    {
        if (!isActive)
        {
            return;
        }

        GameManager.instance.State = GameState.CUTSCENE;
        director.Play();
        buttonTrigger.IsActiveTest = false;
        director.stopped += t =>
        {
            GameManager.instance.State = GameState.RUNNING;
            Application.Quit();
        };

    }

    public void SetDoorActive()
    {
        isActive = true;
        buttonTrigger.IsActiveTest = true;
    }
    #endregion

    #region Messages
    private void OnDisable()
    {
        isActive = false;
        buttonTrigger.IsActiveTest = false;
    } 
    #endregion
}
