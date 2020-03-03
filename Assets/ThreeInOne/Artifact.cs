using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    public List<string> underWaterCollections;
    public List<string> beachRecCollections;
    public List<GameObject> artifactsPlaced;

    public bool groundCollision;
    public GameObject ground;
    public Collections collections;

    //2 combo collections
    public bool strangledFish;
    public bool sunkenShip;

    //3 combo collections
    public bool beerAndWood;
    public bool woodAndLighter;
    public bool lighterAndBeer;
    public bool bonfire;

    /*
    Transform otherArtifactTrans;
    Collider artifactCol;
    Vector3 otherArtifactPos;
    */

    // Start is called before the first frame update
    void Start()
    {
        //artifactCol = gameObject.GetComponentInChildren<SphereCollider>();

      
        
        /*
        strangledFish = collections.strangledFish;
        sunkenShip = collections.sunkenShip;

        bonfire = collections.bonfire;
        beerAndWood = collections.beerAndWood;
        woodAndLighter = collections.woodAndLighter;
        lighterAndBeer = collections.lighterAndBeer;
        */
    }

    // Update is called once per frame
    void Update()
    {
        collections = ground.GetComponent<Collections>();

        beachRecCollections = collections.beachRecCollections;
        underWaterCollections = collections.underWaterCollections;
        artifactsPlaced = collections.artifacts;
        /*
        Vector3 otherArtifactPos = otherArtifactTrans.position;

        if (artifactCol.bounds.Contains(otherArtifactPos))
        {

        };
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            ground = other.gameObject;
            print("found ground");
            groundCollision = true;
        }
     
        if (artifactsPlaced.Contains(other.gameObject) && artifactsPlaced.Contains(transform.parent.gameObject))
        {
            if (transform.parent.name == "Fish" && other.name == "Wood")
            {
                collections.AddToUnderwater("Sunken Ship");
            } 
            else if (transform.parent.name == "Fish" && other.name == "Beer")
            {
                collections.AddToUnderwater("Strangled Fish");
            }

            if (transform.parent.name == "Wood" && other.name == "Fish")
            {
                collections.AddToUnderwater("Sunken Ship");
            }

            if (transform.parent.name == "Beer" && other.name == "Fish")
            {
                collections.AddToUnderwater("Strangled Fish");

            }

            if (transform.parent.name == "Lighter")
            {

            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        {
            if (transform.parent.name == "Fish" && other.name == "Wood")
            {
                collections.RemoveFromUnderwater("Sunken Ship");
            }
            else if (transform.parent.name == "Fish" && other.name == "Beer")
            {
                collections.RemoveFromUnderwater("Strangled Fish");
            }

            if (transform.parent.name == "Wood" && other.name == "Fish")
            {
                collections.RemoveFromUnderwater("Sunken Ship");
            }

            if (transform.parent.name == "Beer" && other.name == "Fish")
            {
                collections.RemoveFromUnderwater("Strangled Fish");

            }

            if (gameObject.name == "Lighter")
            {

            }

      
        }
    }

}