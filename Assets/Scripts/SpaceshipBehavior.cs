using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBehavior : MonoBehaviour
{
    float xPosition;
    float speed;
    public float acceleration;
    public float movementRange;
    public float maxSpeed;
    [SerializeField] [Range(0,1)] float drag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speed -= acceleration * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            speed += acceleration * Time.deltaTime;
        }
        speed = speed * drag;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        xPosition += speed;
        xPosition = Mathf.Clamp(xPosition, -movementRange, movementRange);

        transform.position = new Vector2(xPosition, transform.position.y);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }
}
