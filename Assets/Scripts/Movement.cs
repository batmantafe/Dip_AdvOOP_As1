using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedForward;
    public float rotateSpeed;

    // Use this for initialization
    void Start()
    {
        speedForward = 50f;

        rotateSpeed = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        ForwardMovement();

        VerticalRotate();
    }

    void ForwardMovement()
    {
        transform.Translate(Vector3.forward * (speedForward * Time.deltaTime));
    }

    void VerticalRotate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * (rotateSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-Vector3.right * (rotateSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * (rotateSpeed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * (rotateSpeed * Time.deltaTime));
        }
    }
}
