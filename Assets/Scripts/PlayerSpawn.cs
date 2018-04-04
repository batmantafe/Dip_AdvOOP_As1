using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;

public class PlayerSpawn : NetworkBehaviour
{
    public GameObject mainCamera;

    public GameObject gunnerGun, gunnerTurrent, playerHead, spaceship;
    public bool isPilot, isGunner, nowCheckPlayer;

    void Start()
    {
        Cursor.visible = false;

        isPilot = false;
        isGunner = false;

        LocalPlayerSetup();
    }

    void Update()
    {
        PilotOrGunner();
    }

    void LocalPlayerSetup()
    {
        if (isLocalPlayer)
        {
            mainCamera.SetActive(true);
        }
    }

    void PilotOrGunner()
    {
        if (nowCheckPlayer == true)
        {
            if (isPilot == true)
            {
                playerHead.GetComponent<PilotMouseLook>().enabled = true;
            }

            if (isGunner == true)
            {
                gunnerGun.SetActive(true);
                gunnerTurrent.SetActive(true);

                playerHead.GetComponent<PilotMouseLook>().enabled = false;

                GetComponent<GunnerMouseLook>().enabled = true;

                playerHead.GetComponent<GunnerMouseLook>().enabled = true;

                spaceship.GetComponent<SpaceshipMovement>().enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Pilot SPAWN")
        {
            transform.parent = other.gameObject.transform;
            spaceship = other.gameObject.transform.root.gameObject;
            isPilot = true;
            nowCheckPlayer = true;


        }

        if (other.gameObject.name == "Gunner SPAWN")
        {
            transform.parent = other.gameObject.transform;
            spaceship = other.gameObject.transform.root.gameObject;
            isGunner = true;
            nowCheckPlayer = true;
        }
    }
}
