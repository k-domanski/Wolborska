using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    RUNNING,
    CUTSCENE
}

public class GameManager : MonoBehaviour
{
    #region Properties
    public static GameManager instance;
    public GameState State { get => state; set => state = value; }
    #endregion

    #region Private
    private GameState state = GameState.RUNNING;
    #endregion

    #region Messages
    private void Awake()
    {
        instance = this;
    } 
    #endregion
}
