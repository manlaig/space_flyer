using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerMove : MonoBehaviour {

    public float speed = 5f;
    public Rigidbody rb;
    public GameObject Hero;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, 0);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb.AddForce(movement * speed);

        
    }
}
