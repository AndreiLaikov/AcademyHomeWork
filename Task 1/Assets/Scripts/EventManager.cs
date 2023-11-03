using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action OnDamageRecieved;
    public static Action OnPlayerDead;
    public static Action<Transform> OnNewSpawnPoint;

    public static void SendDamage()
    {
        OnDamageRecieved.Invoke();
    }

    public static void PlayerDead()
    {
        OnPlayerDead.Invoke();
    }

    public static void NewSpawnPoint(Transform pointTransform)
    {
        OnNewSpawnPoint.Invoke(pointTransform);
    }
}
