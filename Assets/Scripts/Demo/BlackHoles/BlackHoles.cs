using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoles : Unit
{

    [SerializeField] GameObject selfExplosion;
    [SerializeField] float maxSpeed = 100f;
    [SerializeField] float minSpeed = 100f;
    [SerializeField] int scoreValue = 10;

    void Start()
    {
        float spd = Mathf.Clamp(Random.value * maxSpeed, minSpeed, maxSpeed);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -spd);
    }
}