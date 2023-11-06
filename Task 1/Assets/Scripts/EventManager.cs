using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action GameStarting;
    public static event Action GameRestarting;
    public static event Action GameEnding;
    public static event Action<int> PlaceSuccess;

    public static void OnGameStarting()
    {
        GameStarting?.Invoke();
    }

    public static void OnGameEnding()
    {
        GameEnding?.Invoke();
    }

    public static void OnPlaceSuccess(int count)
    {
        PlaceSuccess?.Invoke(count);
    }

    public static void OnGameRestarting()
    {
        GameRestarting?.Invoke();
    }
}
