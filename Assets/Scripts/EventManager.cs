using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    static public UnityEvent StartGame = new UnityEvent();
    static public void CallStartGame()
    {
        StartGame.Invoke();
    }
    static public UnityEvent Restart = new UnityEvent();
    static public void CallRestartGame()
    {
        Restart.Invoke();
    }
    static public UnityEvent StopGame = new UnityEvent();
    static public void CallStopGame()
    {
        StopGame.Invoke();
    }
}
