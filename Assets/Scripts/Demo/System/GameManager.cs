using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image TimerBar;
    [SerializeField] GameObject gameOverScreen;

    public static float currCountdownValue;
    float countdownValue = 100;
    bool isGameOver = false;

    void Start()
    {
        StartCoroutine(StartCountdown());
        Events.gameOverEvent += OnGameOver;

        currCountdownValue = countdownValue;
        TimerBar.fillAmount = 1f;
    }

    // will be called when the game is over
    void OnGameOver()
    {
        isGameOver = true;
        gameOverScreen.SetActive(true);
    }

    IEnumerator StartCountdown()
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            TimerBar.fillAmount = currCountdownValue / countdownValue;

            //Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;

            if (isGameOver)
                yield break;
        }
        TimerBar.fillAmount = 0;
        Events.TriggerGameOver();
    }
}
