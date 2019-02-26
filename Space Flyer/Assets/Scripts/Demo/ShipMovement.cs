using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float rotateAngle = 20f;

    Rigidbody rb;
    GameObject Flyer;

    float flyerHealth = 10;

    public GameObject explosive;
    public Transform explodepoint;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();

        flyerHealth.Equals(10);
    }
	
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed;
        //float y = Input.GetAxisRaw("Vertical") * speed;
        float y = 0f;

        if (Input.GetButtonDown("Submit"))
        {
            flyerHealth.Equals(0);
            Debug.Log("DESTROY!!!");
        }

        rb.velocity = new Vector3(x, 0, y);
        rb.rotation = Quaternion.Euler(0, 0, x * rotateAngle);

        if (flyerHealth.Equals(0))
        {
            Instantiate(explosive, explodepoint);
            Destroy(Flyer);
            Debug.Log("DESTROYED!!!");
        }
    }
}
