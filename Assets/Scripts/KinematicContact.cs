﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicContact : MonoBehaviour
{
    private void OnCollisionEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Artifact") == true)
        {

            col.attachedRigidbody.isKinematic = true;

        }
    }

    private void OnCollisionExit(Collider col)
    {
        if (col.gameObject.CompareTag("Artifact") == true)
        {
            col.attachedRigidbody.isKinematic = false;

        }
    }
}
