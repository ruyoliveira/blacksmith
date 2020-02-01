using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float velocity = 5;

    Vector2 input;
    float angle;

    Quaternion targetRotation;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        if (Mathf.Abs(input.x) < 0.1f && Mathf.Abs(input.y) < 0.1f) return;

        Rotate();
        Move();
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void Rotate()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    void Move()
    {
        transform.position += transform.forward * velocity * Time.deltaTime;
    }
}
