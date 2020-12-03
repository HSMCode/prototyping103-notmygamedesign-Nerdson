using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    public float halfPlayerWidth;
    Vector2 screenSize;

    // Start is called before the first frame update
    void Start()
    {
        halfPlayerWidth = transform.localScale.x / -2;
        screenSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth, Camera.main.orthographicSize);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the ship:
        float hAxis = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(hAxis, 0, 0) * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        rb.AddForce(movement);

        // Map Boundaries
        if(transform.position.x < -screenSize.x)
        {
            transform.position = new Vector2(-screenSize.x, transform.position.y);
        }
        else if(transform.position.x > screenSize.x)
        {
            transform.position = new Vector2(screenSize.x, transform.position.y);
        }
    }
}
