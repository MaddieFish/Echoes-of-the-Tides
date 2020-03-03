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

    // Start is called before the first frame update
    void Start()
    {
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
            //If gameObject is Fish
            if (transform.parent.name == "Fish" && other.name == "Wood")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToUnderwater("Sunken Ship");
            } 
            else if (transform.parent.name == "Fish" && other.name == "Beer")
            {
                collections.AddToUnderwater("Strangled Fish");
            }

            //If gameObject is Wood
            if (transform.parent.name == "Wood" && other.name == "Fish")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToUnderwater("Sunken Ship");
            }
            else if (transform.parent.name == "Wood" && other.name == "Beer")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                beerAndWood = true;
            }
            else if (transform.parent.name == "Wood" && other.name == "Lighter")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                woodAndLighter = true;
            }

            //If gameObject is Beer
            if (transform.parent.name == "Beer" && other.name == "Fish")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToUnderwater("Strangled Fish");

            }
            else if (transform.parent.name == "Beer" && other.name == "Wood")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                beerAndWood = true;
            }
            else if (transform.parent.name == "Beer" && other.name == "Lighter")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                lighterAndBeer = true;
            }

            //If gameObject is Lighter
            if (transform.parent.name == "Lighter" && other.name == "Wood")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                woodAndLighter = true;
            }
            else if (transform.parent.name == "Lighter" && other.name == "Beer")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                lighterAndBeer = true;
            }

            if((beerAndWood && woodAndLighter) || (lighterAndBeer && beerAndWood) || (woodAndLighter && lighterAndBeer))
            {
                collections.AddToBeach("Bonfire");
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        {
            //If gameObject is Fish
            if (transform.parent.name == "Fish" && other.name == "Wood")
            {
                collections.RemoveFromUnderwater("Sunken Ship");
            }
            else if (transform.parent.name == "Fish" && other.name == "Beer")
            {
                collections.RemoveFromUnderwater("Strangled Fish");
            }

            //If gameObject is Wood
            if (transform.parent.name == "Wood" && other.name == "Fish")
            {
                collections.RemoveFromUnderwater("Sunken Ship");
            }
            else if (transform.parent.name == "Wood" && other.name == "Beer")
            { 
                beerAndWood = false;
            }
            else if (transform.parent.name == "Wood" && other.name == "Lighter")
            {
                woodAndLighter = false;
            }

            //If gameObject is Beer
            if (transform.parent.name == "Beer" && other.name == "Fish")
            {
                collections.RemoveFromUnderwater("Strangled Fish");

            }
            else if (transform.parent.name == "Beer" && other.name == "Wood")
            {
                beerAndWood = false;
            }
            else if (transform.parent.name == "Beer" && other.name == "Lighter")
            {
                lighterAndBeer = false;
            }

            //If gameObject is Lighter
            if (transform.parent.name == "Lighter" && other.name == "Wood")
            {
                woodAndLighter = false;
            }
            else if (transform.parent.name == "Lighter" && other.name == "Beer")
            {
                lighterAndBeer = false;
            }

            if ((beerAndWood == false && woodAndLighter == false) || (lighterAndBeer == false && beerAndWood == false) || (woodAndLighter ==false && lighterAndBeer ==false))
            {
                collections.RemoveFromBeach("Bonfire");
            }
        }
    }

}