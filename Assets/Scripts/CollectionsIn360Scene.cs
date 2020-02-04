using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsIn360Scene : MonoBehaviour
{
    public GameObject[] artifact;

    public List<Transform> artifactsPlaced = new List<Transform>();
    public List<string> underWaterCollections = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        artifact = GameObject.FindGameObjectsWithTag("Artifact");

        for (int i = 0; i <= artifact.Length; i++)
        {
            underWaterCollections = artifact[i].GetComponent<ArtifactObject>().underWaterCollections;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Only objects tagged "Artifact" can be collected and added to list
    void OnCollisionEnter (Collision col)
    {
    if (col.gameObject.CompareTag("Artifact") == true)
    {
        artifactsPlaced.Add(col.transform);
        //print("You collected " + col.transform.name);
    }

    }
    void OnCollisionExit (Collision col)
    {
        artifactsPlaced.Remove(col.transform);
        //print("You removed the " + col.transform.name);
    }

}
