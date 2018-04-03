using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int xSpeed, ySpeed, zSpeed;

    // Use this for initialization
    void Start()
    {
        xSpeed = Random.Range(15,46);
        ySpeed = Random.Range(15, 46);
        zSpeed = Random.Range(15, 46);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (xSpeed, ySpeed, zSpeed) * Time.deltaTime);
    }
}
