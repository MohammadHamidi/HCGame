using System;
using UnityEngine;
public class GameEventManager:MonoBehaviour
{
    public static event Action StopRunning;
    public static void OnStopRunning()
    {
        StopRunning?.Invoke();
    }

}
