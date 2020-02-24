using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ArtifactProximity : MonoBehaviour
{
    //Artifact collection lists
    public List<Transform> artifactsPlaced = new List<Transform>(); //Artifacts placed on ground
    private readonly List<GameObject> artifacts = new List<GameObject>();
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

    }

    // Update is called once per frame
    void Update()
    {
        FindObjectsProximity();
    }

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

    void FindObjectsProximity()
    {
        for (int i = 0; i < artifacts.Count; i++)
        {
            SphereCollider artifactCollider = artifacts[i].GetComponent<SphereCollider>();
            artifactCollider.radius = triggerDist;

            foreach (Transform otherArtifact in artifactsPlaced)
            {

                print(artifacts[i].name + " " + otherArtifact.name);
                Vector3 otherArtifactPos = otherArtifact.position;
                

                if (otherArtifact && otherArtifact.name != artifacts[i].name)
                {
                    //float dist = Vector3.Distance(otherArtifact.position, artifacts[i].transform.position);
                    //print(artifacts[i].name + " Distance to " + otherArtifact.name + ": " + dist);

                    //Collider[] proximityColliders = Physics.OverlapSphere(otherArtifact.position, triggerDist);
                    //print(artifacts[i].name + " is in proximity of " + otherArtifact.name);

                      if (artifactCollider.name == "Fish" && artifactCollider.bounds.Contains(otherArtifactPos))

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
                    else if (!artifactCollider.bounds.Contains(otherArtifactPos))
                    {
                        if (sunkenShip == true)
                        {
                            underWaterCollections.Remove("Sunken Ship");
                            sunkenShip = false;
                        }

                        if (strangledFish == true)
                        {
                            underWaterCollections.Remove("Strangled Fish");
                            strangledFish = false;
                        }
                    }

                    if (artifactCollider.name == "Wood" && artifactCollider.bounds.Contains(otherArtifactPos))
                    {
                        if (otherArtifact.name == "Fish" && sunkenShip == false)
                        {
                            underWaterCollections.Add("Sunken Ship");
                            sunkenShip = true;
                        }

                        ///Bonfire combo

                        if (bonfire == false && woodAndLighter == true && beerAndWood == true)
                        {
                            beachRecCollections.Add("Bonfire");
                            bonfire = true;
                        }
                        else if (bonfire == true && (woodAndLighter == false || beerAndWood == false))
                        {
                            beachRecCollections.Remove("Bonfire");
                            bonfire = false;
                        }

                        if (otherArtifact.name == "Lighter" && woodAndLighter == false)
                        {
                            woodAndLighter = true;
                        }
                        else if (woodAndLighter == true && !artifactCollider.bounds.Contains(otherArtifactPos))
                        {
                            woodAndLighter = false;
                        }

                        if (otherArtifact.name == "Beer" && beerAndWood == false)
                        {
                            beerAndWood = true;
                        }
                        else if (beerAndWood == true && !artifactCollider.bounds.Contains(otherArtifactPos))
                        {
                            beerAndWood = false;
                        }
                    }
                    else if (!artifactCollider.bounds.Contains(otherArtifactPos))
                    {
                        if (sunkenShip == true)
                        {
                            underWaterCollections.Remove("Sunken Ship");
                            sunkenShip = false;
                        }
                    }

                    if (artifactCollider.name == "Beer" && artifactCollider.bounds.Contains(otherArtifactPos))
                    {
                        if (otherArtifact.name == "Fish" && strangledFish == false)
                        {
                            underWaterCollections.Add("Strangled Fish");
                            strangledFish = true;
                        }

                        /// Bonfire combo

                        if (bonfire == false && lighterAndBeer == true && beerAndWood == true)
                        {
                            beachRecCollections.Add("Bonfire");
                            bonfire = true;
                        }
                        else if (bonfire == true && (lighterAndBeer == false || beerAndWood == false))
                        {
                            beachRecCollections.Remove("Bonfire");
                            bonfire = false;
                        }

                        if (otherArtifact.name == "Lighter" && lighterAndBeer == false)
                        {
                            lighterAndBeer = true;
                        }
                        else if (lighterAndBeer == true && !artifactCollider.bounds.Contains(otherArtifactPos))
                        {
                            lighterAndBeer = false;
                        }

                        if (otherArtifact.name == "Wood" && beerAndWood == false)
                        {
                            beerAndWood = true;
                        }
                        else if (beerAndWood == true && !artifactCollider.bounds.Contains(otherArtifactPos))
                        {
                            beerAndWood = false;
                        }
                    }
                    else if (!artifactCollider.bounds.Contains(otherArtifactPos))
                    {
                        if (strangledFish == true)
                        {
                            underWaterCollections.Remove("Strangled FIsh");
                            strangledFish = false;
                        }
                    }

                    if (artifactCollider.name == "Lighter" && artifactCollider.bounds.Contains(otherArtifactPos))
                    {
                        /// Bonfire combo

                        if (bonfire == false && woodAndLighter == true && lighterAndBeer == true)
                        {
                            beachRecCollections.Add("Bonfire");
                            bonfire = true;
                        }
                        else if (bonfire == true && (woodAndLighter == false || lighterAndBeer == false))
                        {
                            beachRecCollections.Remove("Bonfire");
                            bonfire = false;
                        }

                        if (otherArtifact.name == "Beer" && lighterAndBeer == false)
                        {
                            lighterAndBeer = true;
                        }
                        else if (lighterAndBeer == true && !artifactCollider.bounds.Contains(otherArtifactPos))
                        {
                            lighterAndBeer = false;
                        }

                        if (otherArtifact.name == "Wood" && woodAndLighter == false)
                        {
                            woodAndLighter = true;
                        }
                        else if (beerAndWood == true && !artifactCollider.bounds.Contains(otherArtifactPos))
                        {
                            woodAndLighter = false;
                        }
                    }
                    else if (!artifactCollider.bounds.Contains(otherArtifactPos))
                    {

                    }
                }

            }
        }
    }
}
