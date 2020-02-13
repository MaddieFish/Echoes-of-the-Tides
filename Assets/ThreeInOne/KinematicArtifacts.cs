using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicArtifacts : MonoBehaviour
{
    public bool kinematicsDisabled = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Artifact") == true)
        {
            col.GetComponent<Rigidbody>().isKinematic = false;
        }

    }

    void OnTriggerExit(Collider col)
    {
       

    }
}
