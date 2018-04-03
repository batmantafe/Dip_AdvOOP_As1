using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.Networking;

public class PlayerInput : NetworkBehaviour
{
    public float forwardSpeed;
    public float rotateSpeed;

    public GameObject MainCamera;

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            LocalPlayerStartSetup();

            Cursor.visible = false;

            forwardSpeed = 100f;

            rotateSpeed = 50f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            ForwardMovement();

            VerticalRotate();

            ChangeMode();

            Shortcuts();
        }
    }

    void ForwardMovement()
    {
        transform.Translate(Vector3.forward * (forwardSpeed * Time.deltaTime));
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

    void ChangeMode()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            forwardSpeed = 200f;
            rotateSpeed = 25f;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            forwardSpeed = 50f;
            rotateSpeed = 100f;
        }
    }

    void Shortcuts()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene("Game");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void LocalPlayerStartSetup()
    {
        MainCamera.SetActive(true);
    }
}
