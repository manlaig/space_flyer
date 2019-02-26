using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienFire : MonoBehaviour
{
    [SerializeField] Transform spawn;
    [SerializeField] GameObject laser;

    float cooldownTime = 2f;
    float lastFire = 0f;

    void Update()
    {
        if (Time.time - lastFire >= cooldownTime)
        {
            lastFire = Time.time;
            Instantiate(laser, spawn.position, Quaternion.identity);
        }
    }
}
