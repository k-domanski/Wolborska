using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public Action onGoalsCompleted;
    public Action onAllGoalsCompleted;

    private int _goalsCompleted;

    private void OnEnable()
    {
        New.Goal.onGoalCompleted += HandleGoalCompleted;
    }

    private void OnDisable()
    {
        New.Goal.onGoalCompleted -= HandleGoalCompleted;
    }

    private void HandleGoalCompleted()
    {
        _goalsCompleted++;

        switch(_goalsCompleted)
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
}
