//Reference

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactObject : MonoBehaviour
{
    public float triggerDist = 0.5f;

    //2 combo collections
    public GameObject ground;
    public bool strangledFish = false;
    public bool sunkenShip = false;

    //3 combo collections
    public bool beerAndWood = false;
    public bool woodAndLighter = false;
    public bool lighterAndBeer = false;
    public bool bonfire = false;
    

    public List<Transform> artifactsPlaced = new List<Transform>();

    public List<string> underWaterCollections = new List<string>();

    //public List<Transform> other = new List<Transform>();
    //public Transform other;


    //public GameObject other;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.FindWithTag("Ground");

        if (ground != null)
        {
            artifactsPlaced = ground.GetComponent<CollectionsIn360Scene>().artifactsPlaced;
        }
        //CollectionsIn360Scene = GameObject.Find("Ground").GetComponent<script>();
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectsProximity();
    }

    void FindObjectsProximity()
    {

        foreach (Transform otherArtifact in artifactsPlaced)
        {
            if (otherArtifact && otherArtifact.name != gameObject.name)
            {
                float dist = Vector3.Distance(otherArtifact.position, transform.position);
                print(gameObject.name + " Distance to " + otherArtifact.name + ": " + dist);

                if (dist <= triggerDist && gameObject.name == "Fish")
                {
                    if (otherArtifact.name == "Wood" && sunkenShip == false)
                    {
                        underWaterCollections.Add("Sunken Ship");
                        sunkenShip = true;

                    }

                    if (otherArtifact.name == "Beer" && strangledFish == false)
                    {
                        underWaterCollections.Add("Strangled Fish");
                        strangledFish = true;
                    }

                }
                else
                {
                    if (sunkenShip == true && dist > triggerDist)
                    {
                        underWaterCollections.Remove("Sunken Ship");
                        sunkenShip = false;
                    }

                    if (strangledFish == true && dist > triggerDist)
                    {
                        underWaterCollections.Remove("Strangled Fish");
                        strangledFish = false;
                    }
                }

                if (dist <= triggerDist && gameObject.name == "Wood")
                {
                    if (otherArtifact.name == "Fish" && sunkenShip == false)
                    {
                        underWaterCollections.Add("Sunken Ship");
                        sunkenShip = true;
                    }

                    ///Bonfire combo

                    if (bonfire == false && woodAndLighter == true && beerAndWood == true)
                    {
                        underWaterCollections.Add("Bonfire");
                        bonfire = true;
                    }
                    else if (bonfire == true && (woodAndLighter == false || beerAndWood == false))
                    {
                        underWaterCollections.Remove("Bonfire");
                        bonfire = false;
                    }

                    if (otherArtifact.name == "Lighter" && woodAndLighter == false)
                    {
                        woodAndLighter = true;
                    }
                    else if (woodAndLighter == true && dist > triggerDist)
                    {
                        woodAndLighter = false;
                    }

                    if (otherArtifact.name == "Beer" && beerAndWood == false)
                    {
                        beerAndWood = true;
                    }
                    else if (beerAndWood == true && dist > triggerDist)
                    {
                        beerAndWood = false;
                    }
                }
                else
                {
                    if (sunkenShip == true && dist > triggerDist)
                    {
                        underWaterCollections.Remove("Sunken Ship");
                        sunkenShip = false;
                    }
                }

                if (dist <= triggerDist && gameObject.name == "Beer")
                {
                    if (otherArtifact.name == "Fish" && strangledFish == false)
                    {
                        underWaterCollections.Add("Strangled Fish");
                        strangledFish = true;
                    }

                    /// Bonfire combo

                    if (bonfire == false && lighterAndBeer == true && beerAndWood == true)
                    {
                        underWaterCollections.Add("Bonfire");
                        bonfire = true;
                    }
                    else if (bonfire == true && (lighterAndBeer == false || beerAndWood == false))
                    {
                        underWaterCollections.Remove("Bonfire");
                        bonfire = false;
                    }

                    if (otherArtifact.name == "Lighter" && lighterAndBeer == false)
                    {
                        lighterAndBeer = true;
                    }
                    else if (lighterAndBeer == true && dist > triggerDist)
                    {
                        lighterAndBeer = false;
                    }

                    if (otherArtifact.name == "Wood" && beerAndWood == false)
                    {
                        beerAndWood = true;
                    }
                    else if (beerAndWood == true && dist > triggerDist)
                    {
                        beerAndWood = false;
                    }
                }
                else
                {
                    if (strangledFish == true && dist > triggerDist)
                    {
                        underWaterCollections.Remove("Strangled FIsh");
                        strangledFish = false;
                    }
                }

                if (dist <= triggerDist && gameObject.name == "Lighter")
                {
                    /// Bonfire combo

                    if (bonfire == false && woodAndLighter == true && lighterAndBeer == true)
                    {
                        underWaterCollections.Add("Bonfire");
                        bonfire = true;
                    }
                    else if (bonfire == true && (woodAndLighter == false || lighterAndBeer == false))
                    {
                        underWaterCollections.Remove("Bonfire");
                        bonfire = false;
                    }

                    if (otherArtifact.name == "Beer" && lighterAndBeer == false)
                    {
                        lighterAndBeer = true;
                    }
                    else if (lighterAndBeer == true && dist > triggerDist)
                    {
                        lighterAndBeer = false;
                    }

                    if (otherArtifact.name == "Wood" && woodAndLighter == false)
                    {
                        woodAndLighter = true;
                    }
                    else if (beerAndWood == true && dist > triggerDist)
                    {
                        woodAndLighter = false;
                    }
                }
                else
                {

                }
            }
        }

    }
    /*
    void FindObjectsProximity()
    {

        foreach (Transform otherArtifact in artifactsPlaced)
        {
            if (otherArtifact && otherArtifact.name != gameObject.name)
            {
                float dist = Vector3.Distance(otherArtifact.position, transform.position);
                print(gameObject.name + " Distance to " + otherArtifact.name + ": " + dist);

                if (dist <= triggerDist && gameObject.name == "Fish")
                {
                    if (otherArtifact.name == "Wood" && sunkenShip == false)
                    {
                        underWaterCollections.Add("Sunken Ship");
                        sunkenShip = true;

                    }

                    if (otherArtifact.name == "Beer" && strangledFish == false)
                    {
                        underWaterCollections.Add("Strangled Fish");
                        strangledFish = true;
                    }
                
                } 
                else
                {
                    if (sunkenShip == true && dist > triggerDist)
                    {
                        underWaterCollections.Remove("Sunken Ship");
                        sunkenShip = false;
                    }

                    if (strangledFish == true && dist > triggerDist)
                    {
                        underWaterCollections.Remove("Strangled Fish");
                        strangledFish = false;
                    }
                }

                if (dist <= triggerDist && gameObject.name == "Wood")
                {
                    if (otherArtifact.name == "Fish" && sunkenShip == false)
                    {
                        underWaterCollections.Add("Sunken Ship");
                        sunkenShip = true;
                    }
                 
                    ///Bonfire combo

                    if (bonfire == false && woodAndLighter == true && beerAndWood == true)
                    {
                        underWaterCollections.Add("Bonfire");
                        bonfire = true;
                    } 
                    else if (bonfire == true && (woodAndLighter == false || beerAndWood == false))
                    {
                        underWaterCollections.Remove("Bonfire");
                        bonfire = false;
                    }

                    if (otherArtifact.name == "Lighter" && woodAndLighter == false)
                    {
                        woodAndLighter = true;
                    }
                    else if (woodAndLighter == true && dist > triggerDist)
                    {
                        woodAndLighter = false;
                    }

                    if (otherArtifact.name == "Beer" && beerAndWood == false)
                    {
                        beerAndWood = true;
                    }
                    else if (beerAndWood == true && dist > triggerDist)
                    {
                        beerAndWood = false;
                    }
                } 
                else
                {
                    if (sunkenShip == true && dist > triggerDist)
                    {
                        underWaterCollections.Remove("Sunken Ship");
                        sunkenShip = false;
                    }
                }

                if (dist <= triggerDist && gameObject.name == "Beer")
                {
                    if (otherArtifact.name == "Fish" && strangledFish == false)
                    {
                        underWaterCollections.Add("Strangled Fish");
                        strangledFish = true;
                    }
                    
                    /// Bonfire combo

                    if (bonfire == false && lighterAndBeer == true && beerAndWood == true)
                    {
                        underWaterCollections.Add("Bonfire");
                        bonfire = true;
                    }
                    else if (bonfire == true && (lighterAndBeer == false || beerAndWood == false))
                    {
                        underWaterCollections.Remove("Bonfire");
                        bonfire = false;
                    }

                    if (otherArtifact.name == "Lighter" && lighterAndBeer == false)
                    {
                        lighterAndBeer = true;
                    }
                    else if (lighterAndBeer == true && dist > triggerDist)
                    {
                        lighterAndBeer = false;
                    }

                    if (otherArtifact.name == "Wood" && beerAndWood == false)
                    {
                        beerAndWood = true;
                    }
                    else if (beerAndWood == true && dist > triggerDist)
                    {
                        beerAndWood = false;
                    }
                } 
                else
                {
                    if (strangledFish == true && dist > triggerDist)
                    {
                        underWaterCollections.Remove("Strangled FIsh");
                        strangledFish = false;
                    }
                }

                if (dist <= triggerDist && gameObject.name == "Lighter")
                {
                    /// Bonfire combo

                    if (bonfire == false && woodAndLighter == true && lighterAndBeer == true)
                    {
                        underWaterCollections.Add("Bonfire");
                        bonfire = true;
                    }
                    else if (bonfire == true && (woodAndLighter == false || lighterAndBeer == false))
                    {
                        underWaterCollections.Remove("Bonfire");
                        bonfire = false;
                    }

                    if (otherArtifact.name == "Beer" && lighterAndBeer == false)
                    {
                        lighterAndBeer = true;
                    }
                    else if (lighterAndBeer == true && dist > triggerDist)
                    {
                        lighterAndBeer = false;
                    }

                    if (otherArtifact.name == "Wood" && woodAndLighter == false)
                    {
                        woodAndLighter = true;
                    }
                    else if (beerAndWood == true && dist > triggerDist)
                    {
                        woodAndLighter = false;
                    }
                } 
                else
                {

                }
            }
        }
       
    }
    */

}
