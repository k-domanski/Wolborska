using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    #region Events
    public Action onGoalsCompleted;
    public Action onAllGoalsCompleted;
    #endregion

    #region Private
    private int _goalsCompleted;
    #endregion

    #region Messages
    private void OnEnable()
    {
        Goal.onGoalCompleted += HandleGoalCompleted;
    }

    private void OnDisable()
    {
        Goal.onGoalCompleted -= HandleGoalCompleted;
    }
    #endregion

    #region Private Methods
    private void HandleGoalCompleted()
    {
        _goalsCompleted++;

        switch (_goalsCompleted)
        {
            case 2:
                onGoalsCompleted?.Invoke();
                break;
            case 4:
                onAllGoalsCompleted?.Invoke();
                break;
            default:
                break;
        }
    } 
    #endregion
}
