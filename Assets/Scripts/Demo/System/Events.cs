using System;
using UnityEngine;

public static class Events
{
    public static Action gameOverEvent, gamePausedEvent;

    public static void TriggerGameOver()
    {
        Debug.Log("Game Over Event");
        if (gameOverEvent != null)
            gameOverEvent();
    }

    public static void TriggerGamePaused()
    {
        if (gamePausedEvent != null)
            gamePausedEvent();
    }
}
