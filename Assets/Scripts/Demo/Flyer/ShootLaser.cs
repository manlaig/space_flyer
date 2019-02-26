using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour
{
    [SerializeField] Transform leftSpawn, rightSpawn;
    [SerializeField] GameObject laser;

    float cooldownTime = 0.2f;
    float lastFire = 0f;

    void Update ()
    {
		if(Input.GetAxisRaw("Fire1") != 0f && Time.time - lastFire >= cooldownTime)
        {
            lastFire = Time.time;
            Instantiate(laser, leftSpawn);
            Instantiate(laser, rightSpawn);
        }
	}
}
