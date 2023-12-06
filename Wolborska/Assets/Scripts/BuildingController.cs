using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BuildingController : MonoBehaviour
{
    #region Properties
    [SerializeField] private GameObject _buildingModel;
    [SerializeField] private GoalManager _goalManager;
    [SerializeField] private FollowPath _indicator;
    #endregion

    #region Private
    private PlayableDirector _animation;
    private ActionOnTrigger _actionOnTrigger;
    private Door _door;
    #endregion

    #region Messages
    private void Awake()
    {
        _buildingModel.SetActive(false);
        _animation = _buildingModel.GetComponent<PlayableDirector>();
        _actionOnTrigger = GetComponentInChildren<ActionOnTrigger>();
        _door = GetComponentInChildren<Door>();
    }

    private void OnEnable()
    {
        _goalManager.onGoalsCompleted += ShowBuilding;
        _goalManager.onAllGoalsCompleted += HandleAllGoalsCompleted;
    }

    private void OnDisable()
    {
        _goalManager.onGoalsCompleted -= ShowBuilding;
        _goalManager.onAllGoalsCompleted -= HandleAllGoalsCompleted;
        _animation.stopped -= HandleAnimationStopped;
    }
    #endregion

    #region Private Methods
    private void ShowBuilding()
    {
        _buildingModel.SetActive(true);
    }

    private void HandleAllGoalsCompleted()
    {
        _indicator.gameObject.SetActive(true);
        _indicator.Activate();
        _actionOnTrigger.SetAction(RepairMemory);
    }

    private void RepairMemory()
    {
        GameManager.instance.State = GameState.CUTSCENE;
        _animation.Play();
        _animation.stopped += HandleAnimationStopped;
    }

    private void HandleAnimationStopped(PlayableDirector directon)
    {
        _door.Activate();
        GameManager.instance.State = GameState.RUNNING;
    }
    #endregion
}
