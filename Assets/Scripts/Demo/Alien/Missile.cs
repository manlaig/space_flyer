using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Unit
{
    [SerializeField] GameObject selfExplosion;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(MoveTowardsPlayer());
    }

    IEnumerator MoveTowardsPlayer()
    {
        if (player)
            while(transform.position != player.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, 1f);
                yield return null;
            }
    }

    void OnTriggerEnter(Collider other)
    {
        Unit collidedUnit = other.gameObject.GetComponent<Unit>();
        if(collidedUnit)
        {
            Destroy(Instantiate(selfExplosion, transform.position, transform.rotation), 1.5f);
            Destroy(gameObject);
        }
    }
}
