using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField] private GameObject buildingModel;
    private int goalsCompleted;

    private void Awake()
    {
        buildingModel.SetActive(false);
        Goal.onGoalCompleted += ManageBuilding;
    }

    private void ManageBuilding()
    {
        goalsCompleted++;

        if (goalsCompleted == 2)
            ShowBuilding();
        else if (goalsCompleted == 4)
            RepairMemory();
    }

    private void RepairMemory()
    {
        throw new NotImplementedException();
    }

    private void ShowBuilding()
    {
        buildingModel.SetActive(true);
    }
}
