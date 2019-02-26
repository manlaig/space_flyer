using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Drop either time or health boost when destroyed 
 */

 [RequireComponent(typeof(Asteroid))]
public class DropBoost : MonoBehaviour
{

    [SerializeField] int healthBoost;
    [SerializeField] int timeBoost;


    enum BoostTypes
    {
        Time, Health
    }

    Asteroid ast;
    BoostTypes dropType;

    void Start()
    {
        ast = GetComponent<Asteroid>();
        dropType = (BoostTypes)Random.Range(0, 2);
    }

    public void Drop()
    {
        if (dropType == BoostTypes.Time)
        {
            float timeLeft = GameManager.currCountdownValue;
            GameManager.currCountdownValue = Mathf.Clamp(timeLeft + timeBoost, 0, 100);
            Debug.Log("time increased");
        }
        else if (dropType == BoostTypes.Health)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                player.GetComponent<ShipHealth>().IncreaseHealth(healthBoost);
                Debug.Log("increased health");
            }
        }
    }
}
