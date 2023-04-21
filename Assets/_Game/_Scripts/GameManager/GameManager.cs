using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    MainMenu,
    Gameplay,
    Pause,
}
public class GameManager : Singleton<GameManager>
{
    private GameState gameState;
    public void ChangStateGame(GameState state)
    {
        this.gameState = state;
    }
    public bool IsState(GameState state)
    {
        return this.gameState == state;
    }
}
