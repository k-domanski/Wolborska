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
    public static GameManager instance;
    public GameState State { get => state; set => state = value; }

    private GameState state = GameState.RUNNING;
    private void Awake()
    {
        instance = this;
    }
}
