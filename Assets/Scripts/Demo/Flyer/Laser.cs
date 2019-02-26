using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Unit
{
    [SerializeField] float speed = 10f;
    [SerializeField] float timer = 0.02f;

    void Start ()
    {
        Vector3 velocity = new Vector3(0, 0, speed);

        // rotating the bullet a little bit when player fires
        if(transform.parent)
            velocity.x = transform.parent.rotation.y * speed;
        GetComponent<Rigidbody>().velocity = velocity;

        Destroy(gameObject, timer);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Unit>())
        {
            Destroy(gameObject);
        }
    }
}
