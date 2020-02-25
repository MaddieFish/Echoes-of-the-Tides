using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    Transform otherArtifactTrans;

    Collider artifactCol;
    Vector3 otherArtifactPos;

    // Start is called before the first frame update
    void Start()
    {
        artifactCol = gameObject.GetComponentInChildren<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 otherArtifactPos = otherArtifactTrans.position;

        if (artifactCol.bounds.Contains(otherArtifactPos))
        {

        };

    }
}
