using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float speed = 175f;
    [SerializeField] float rotateAngle = 5f;

    Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed;
        float y = Input.GetAxisRaw("Vertical") * speed;

        rb.velocity = new Vector3(x, 0, 0);
        rb.rotation = Quaternion.Euler(0, 0, rotateAngle);

#if !UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            Time.timeScale = 1f;
            Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
            if (touch.phase != TouchPhase.Moved)
                return;
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, speed));

            transform.position = new Vector3(pos.x, 0, pos.z -= 15);
        }
        else if (Input.touchCount == 0)
        {
            Time.timeScale = 0.2f;
        }
#endif
    }
}
