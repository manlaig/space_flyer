using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Asteroid : Unit
{
    [SerializeField] GameObject selfExplosion;
    [SerializeField] float maxSpeed = 100f;
    [SerializeField] float minSpeed = 20f;
    [SerializeField] int scoreValue = 10;

    Asteroid ast;

    enum AsteroidSize
    {
        Small = 1, Medium = 2, Large = 3
    }

    void Start()
    {
        float spd = Mathf.Clamp(Random.value * maxSpeed, minSpeed, maxSpeed);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -spd);

        float randRot = Random.Range(25, 100);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(randRot, randRot, randRot);

        ast = GetComponent<Asteroid>();

        int size = Random.Range(1, 3);
        transform.localScale = new Vector3(size, size, size);

        AsteroidSize sizing = (AsteroidSize) size;

        if (sizing == AsteroidSize.Small)
            health = 1;
        else if (sizing == AsteroidSize.Medium)
            health = 30;
        else if (sizing == AsteroidSize.Large)
            health = 80;
    }

    void OnTriggerEnter(Collider other)
    {
        HandleCollision(other.gameObject);
    }

    void HandleCollision(GameObject go)
    {
        Unit collidedGO = go.GetComponent<Unit>();
        if (collidedGO)
        {
            health -= collidedGO.damage;
        }
        if (health <= 0 || go.tag == "Player")
        {
            Destroy(Instantiate(selfExplosion, transform.position, transform.rotation), 1.5f);
            Destroy(gameObject);
        }
    }

    void SelfDestruct()
    {
        DropBoost boost = GetComponent<DropBoost>();
        if (boost)
            boost.Drop();

        CurrentScore.score += scoreValue;
        Destroy(Instantiate(selfExplosion, transform.position, transform.rotation), 1.5f);
        Destroy(gameObject);
    }
}
