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
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            ForwardMovement();

            VerticalRotate();

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

        Cursor.visible = false;

        forwardSpeed = 100f;

        rotateSpeed = 50f;
    }
}
