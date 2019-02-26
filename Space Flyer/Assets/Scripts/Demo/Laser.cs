using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float speed = 10f;

	void Start ()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(transform.parent.rotation.y * speed, 0, speed);
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with something");
    }
}
