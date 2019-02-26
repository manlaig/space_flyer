using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameover;
    [SerializeField] GameObject player;


    void Start()
    {
        gameover.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Events.gameOverEvent += PlayGameOver;
    }

    void PlayGameOver()
    {
        gameover.SetActive(true);
        Destroy(player);
    }
}
