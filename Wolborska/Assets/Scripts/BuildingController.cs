using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BuildingController : MonoBehaviour
{
    #region Properties
    [SerializeField] private GameObject buildingModel;
    [SerializeField] private PlayableDirector director;
    [SerializeField] private FollowPath indicator;
    [SerializeField] private Door door;
    #endregion

    #region Private
    private int goalsCompleted;
    private bool canRepair;
    #endregion

    #region Messages
    private void Awake()
    {
        director.gameObject.SetActive(false);
        indicator.gameObject.SetActive(false);
        Goal.onGoalCompleted += ManageBuilding;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>() && canRepair)
            RepairMemory();
    }
    #endregion

    #region Private Methods
    private void ManageBuilding()
    {
        goalsCompleted++;

        if (goalsCompleted == 2)
            ShowBuilding();
        else if (goalsCompleted == 4)
        {
            canRepair = true;
            indicator.gameObject.SetActive(true);
            indicator.CanMove = true;
        }
    }

    private void RepairMemory()
    {
        GameManager.instance.State = GameState.CUTSCENE;
        director.Play();
        director.stopped += t =>
        {
            door.SetDoorActive();
            canRepair = false;
            GameManager.instance.State = GameState.RUNNING;
        };
    }

    private void ShowBuilding()
    {
        director.gameObject.SetActive(true);
    } 
    #endregion
}
