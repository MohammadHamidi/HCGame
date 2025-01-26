using System;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance;
    private GameState gameState;
    public static Action<GameState> onGameStateChanged;

    public enum GameState 
    {
        Menu,
        Game,
        LevelComplete,
        GameOver
    }

    private void Awake() 
    {
        if (instance != null) 
        {
            Destroy(gameObject);
        }
        else 
        {
            instance = this;
        }
    }

    public void SetGameState(GameState state) 
    {
        gameState = state;
        onGameStateChanged?.Invoke(state);
    }

    public bool IsGameState() 
    {
        return gameState == GameState.Game;
    }
}