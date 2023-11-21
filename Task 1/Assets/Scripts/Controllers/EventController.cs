using System;

public static class EventController
{
    public static event Action OnGameStarting;
    public static event Action OnGameRestarting;
    public static event Action OnBlockRightPlacing;
    public static event Action OnBlockWrongPlacing;

    public static void GameStart()
    {
        OnGameStarting?.Invoke();
    }

    public static void GameRestart()
    {
        OnGameRestarting?.Invoke();
    }

    public static void PlaceRight()
    {
        OnBlockRightPlacing?.Invoke();
    }

    public static void PlaceWrong()
    {
        OnBlockWrongPlacing?.Invoke();
    }
}
