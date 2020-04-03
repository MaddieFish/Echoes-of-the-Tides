//Reference: Brackeys Smooth Portals in Unity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;

    public bool playerIsOverlapping = false;
    public float dotProduct;

    private Rigidbody PailRB;

    void Start()
    {
        GameObject Pail = GameObject.Find("Pail Body Square");
        if (Pail != null)
        {
            PailRB = Pail.GetComponent<Rigidbody>();
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(PailRB.isKinematic == true)
        {
            PailRB.isKinematic = false;
        }

        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //If this is true the player has moved across the portal
            if (dotProduct < 0f){
                //teleport
                PailRB.isKinematic = true;
                float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerIsOverlapping = false;
                
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
