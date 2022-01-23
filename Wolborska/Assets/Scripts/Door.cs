using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class Door : AInteractable
{
    [SerializeField] private PlayableDirector director;
    public override void Interact()
    {
        if (!isActive)
        {
            return;
        }

        GameManager.instance.State = GameState.CUTSCENE;
        director.Play();
        buttonTrigger.IsActiveTest = false;
        director.stopped += t => GameManager.instance.State = GameState.RUNNING;

    }

    public void SetDoorActive()
    {
        isActive = true;
        buttonTrigger.IsActiveTest = true;
    }

    private void OnEnable()
    {
        //isActive = true;
        //buttonTrigger.IsActiveTest = true;
    }

    private void OnDisable()
    {
        isActive = false;
        buttonTrigger.IsActiveTest = false;
    }
}
