﻿//Reference: Brackeys Smooth Portals in Unity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;


    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        //Quaternion portalRotationdDiffernce = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Quaternion portalRotationdDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.forward);

        Vector3 newCameraDirection = portalRotationdDifference * playerCamera.forward;
        //transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        transform.rotation = playerCamera.rotation;
    }
}
