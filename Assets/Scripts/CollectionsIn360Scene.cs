using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsIn360Scene : MonoBehaviour
{
    //public GameObject[] artifact;

    //Artifact collection lists
    public List<Transform> artifactsPlaced = new List<Transform>(); //Artifacts placed on ground
    private List<GameObject> artifacts = new List<GameObject>();
    public List<string> underWaterCollections = new List<string>();
    public List<string> beachRecCollections = new List<string>();

    public float triggerDist = 0.5f;

    //Choose scene
    public bool underWaterScene;
    public bool beachRecScene;


    //2 combo collections
    public bool strangledFish = false;
    public bool sunkenShip = false;

    //3 combo collections
    public bool beerAndWood = false;
    public bool woodAndLighter = false;
    public bool lighterAndBeer = false;
    public bool bonfire = false;


    // Start is called before the first frame update
    void Start()
    {
        //artifact = GameObject.FindGameObjectsWithTag("Artifact");

    }

    // Update is called once per frame
    void Update()
    {
        FindObjectsProximity();
    }


    //Only objects tagged "Artifact" can be collected and added to list
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Artifact") == true)
        {
            artifactsPlaced.Add(col.transform);
            artifacts.Add(col.gameObject);

            //print("You collected " + col.transform.name);
        }

    }
    void OnCollisionExit(Collision col)
    {
        artifactsPlaced.Remove(col.transform);
        artifacts.Remove(col.gameObject);
        //print("You removed the " + col.transform.name);
    }

    void SpawnComboObject()
    {
        if (sunkenShip == true && underWaterScene == true)
        {

        }

        if (bonfire == true && beachRecScene == true)
        {

        }
    }

    void FindObjectsProximity()
    {
        for (int i = 0; i < artifacts.Count; i++)
        {  
     
            foreach (Transform otherArtifact in artifactsPlaced)
            {
                print(artifacts[i].name + " " + otherArtifact.name);

                if (otherArtifact && otherArtifact.name != artifacts[i].name)
                {
                    float dist = Vector3.Distance(otherArtifact.position, artifacts[i].transform.position);
                    print(artifacts[i].name + " Distance to " + otherArtifact.name + ": " + dist);

                    if (dist <= triggerDist && artifacts[i].name == "Fish")
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

                    if (dist <= triggerDist && artifacts[i].name == "Wood")
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

                    if (dist <= triggerDist && artifacts[i].name == "Beer")
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

                    if (dist <= triggerDist && artifacts[i].name == "Lighter")
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
    }

      


}
