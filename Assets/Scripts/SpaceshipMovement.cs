using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float forwardSpeed;
    public float rotateSpeed;

    // Use this for initialization
    void Start()
    {
        forwardSpeed = 50f;

        rotateSpeed = 25f;
    }

    // Update is called once per frame
    void Update()
    {
        ForwardMovement();
    }

    void ForwardMovement()
    {
        transform.Translate(Vector3.forward * (forwardSpeed * Time.deltaTime));
    }
}
