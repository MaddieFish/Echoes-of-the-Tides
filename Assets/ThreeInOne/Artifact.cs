using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach script to Artifacts Sphere Trigger Collider on child Gameobject
//Keeps track of artifacts within triggering proximity of eachother

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
    public bool strangledTurtle;
    public bool sunkenShip;
    public bool guitar;
    //public bool stereo;
    public bool bonfire;
    public bool aquarium;
    public bool cooler;
    public bool turtleHatching;

    //3 combo collections
    //public bool beerAndWood;
    //public bool lighterAndBeer;

    public bool bonfireWithRack;
    public bool fishAndWood;
    public bool woodAndLighter;
    public bool lighterAndFish;

    public bool stereo;
    public bool cdandMetal;
    public bool metalandPlastic;
    public bool plasticandCD;

    public bool metalandWire;
    public bool wireAndCD;

    // Update is called once per frame
    void Update()
    {
        if (ground != null)
        {
            collections = ground.GetComponent<Collections>();
        }
        if (collections != null)
        {
            beachRecCollections = collections.beachRecCollections;
            underWaterCollections = collections.underWaterCollections;
            artifactsPlaced = collections.artifacts;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (ground == null && other.CompareTag("Ground"))
        {
            groundCollision = true;
            ground = other.gameObject;
        }
        else
        {
            groundCollision = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        /*
        if (collections != null)
        {
            return;
        }
        */
        if (artifactsPlaced.Contains(other.gameObject) && artifactsPlaced.Contains(transform.parent.gameObject))
        {
            //If gameObject is Fish
            if (transform.parent.name == "Fish" && other.name == "Wood")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToUnderwater("Sunken Ship");

                fishAndWood = true;
            } 
            else if (transform.parent.name == "Fish" && other.name == "Beer")
            {
                collections.AddToUnderwater("Strangled Fish");
            }
            else if (transform.parent.name == "Fish" && other.name == "Lighter")
            {
                lighterAndFish = true;
            }

            //If gameObject is Wood
            if (transform.parent.name == "Wood" && other.name == "Fish")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToUnderwater("Sunken Ship");

                fishAndWood = true;
            }
            else if (transform.parent.name == "Wood" && other.name == "Beer")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                //beerAndWood = true;
            }
            else if (transform.parent.name == "Wood" && other.name == "Lighter")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                woodAndLighter = true;

                collections.AddToBeach("Bonfire");
            }
            else if (transform.parent.name == "Wood" && other.name == "Glass")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToUnderwater("Aquarium");
            }
            else if (transform.parent.name == "Wood" && other.name == "Wire")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToBeach("Guitar");
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

                //beerAndWood = true;
            }
            else if (transform.parent.name == "Beer" && other.name == "Lighter")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                //lighterAndBeer = true;
            }
            else if (transform.parent.name == "Beer" && other.name == "Turtle Egg")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToUnderwater("Strangled Turtle");
            }
            else if (transform.parent.name == "Beer" && other.name == "Plastic")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToBeach("Cooler");
            }

            //If gameObject is Lighter
            if (transform.parent.name == "Lighter" && other.name == "Wood")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                woodAndLighter = true;
                collections.AddToBeach("Bonfire");
            }
            else if (transform.parent.name == "Lighter" && other.name == "Fish")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                lighterAndFish = true;
            }
            else if (transform.parent.name == "Lighter" && other.name == "Beer")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                //lighterAndBeer = true;
            }

            //If gameObject is CD
            if(transform.parent.name == "CD" && other.name == "Plastic")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                plasticandCD = true;
            }
            else if (transform.parent.name == "CD" && other.name == "Metal")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                cdandMetal = true;
            }
            else if (transform.parent.name == "CD" && other.name == "Wire")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                wireAndCD = true;
            }

            //If gameObject is Turtle Egg
            if (transform.parent.name == "Turtle Egg" && other.name == "Beer")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToUnderwater("Strangled Turtle");
            }
            else if (transform.parent.name == "Turtle Egg" && other.name == "Turtle Egg")
            {
                print(transform.parent.name + " is in proximity of " + other.name);
                collections.AddToBeach("Turtle Hatch");
            }

            //If gameObject is Plastic (plastic box or container)
            if (transform.parent.name == "Plastic" && other.name == "CD")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                plasticandCD = true;
            }
            else if (transform.parent.name == "Plastic" && other.name == "Metal")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                metalandPlastic = true;
            }
            else if (transform.parent.name == "Plastic" && other.name == "Beer")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToBeach("Cooler");
            }

            //If gameObject is Metal
            if (transform.parent.name == "Metal" && other.name == "CD")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                cdandMetal = true;
            }
            else if (transform.parent.name == "Metal" && other.name == "Plastic")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                metalandPlastic = true;
            }
            else if (transform.parent.name == "Metal" && other.name == "Wire")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                metalandWire = true;
            }

            //If gameObject is Glass
            if (transform.parent.name == "Glass" && other.name == "Fish")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToUnderwater("Aquarium");
            }

            //If gameObject is Wire
            else if (transform.parent.name == "Wire" && other.name == "Wood")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                collections.AddToBeach("Guitar");
            }
            else if (transform.parent.name == "Wire" && other.name == "CD")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                wireAndCD = true;
            }
            else if (transform.parent.name == "Wire" && other.name == "Metal")
            {
                print(transform.parent.name + " is in proximity of " + other.name);

                metalandWire = true;
            }

            //3 Artifact Combos
          
            if ((fishAndWood && woodAndLighter) || (lighterAndFish && fishAndWood) || (woodAndLighter && lighterAndFish))
            {
                collections.AddToBeach("Bonfire with Rack");
            }
           
            if ((cdandMetal && metalandPlastic) || (plasticandCD && cdandMetal) || (metalandPlastic && plasticandCD))
            {
                collections.AddToBeach("Stereo");
            }

            if ((cdandMetal && metalandWire) || (wireAndCD && cdandMetal) || (metalandWire && wireAndCD))
            {
                collections.AddToBeach("Stereo");
            }

            /*
            //old bonfire
            if((beerAndWood && woodAndLighter) || (lighterAndBeer && beerAndWood) || (woodAndLighter && lighterAndBeer))
            {
                collections.AddToBeach("Bonfire");
            }
            */
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (ground != null && other.CompareTag("Ground"))
        {
            groundCollision = false;
            ground = null;
            collections = null;
        }
        else
        {
            groundCollision = true;
        }

        if (collections == null)
        {
            return;
        }

        //If gameObject is Fish
        if (transform.parent.name == "Fish" && other.name == "Wood")
                {
                collections.RemoveFromUnderwater("Sunken Ship");
                fishAndWood = false;
            }
            else if (transform.parent.name == "Fish" && other.name == "Beer")
            {
                collections.RemoveFromUnderwater("Strangled Fish");
            }
            else if (transform.parent.name == "Fish" && other.name == "Lighter")
            {
                lighterAndFish = false;
            }

        //If gameObject is Wood
        if (transform.parent.name == "Wood" && other.name == "Fish")
            {
                collections.RemoveFromUnderwater("Sunken Ship");
                fishAndWood = false;
            }
            else if (transform.parent.name == "Wood" && other.name == "Beer")
            { 
                //beerAndWood = false;
            }
            else if (transform.parent.name == "Wood" && other.name == "Lighter")
            {
                woodAndLighter = false;
                collections.RemoveFromBeach("Bonfire");
            }
            else if (transform.parent.name == "Wood" && other.name == "Glass")
            {
                collections.RemoveFromUnderwater("Aquarium");
            }
            else if (transform.parent.name == "Wood" && other.name == "Wire")
            {
                collections.RemoveFromBeach("Guitar");
            }

            //If gameObject is Beer
            if (transform.parent.name == "Beer" && other.name == "Fish")
            {
                collections.RemoveFromUnderwater("Strangled Fish");

            }
            else if (transform.parent.name == "Beer" && other.name == "Wood")
            {
                //beerAndWood = false;
            }
            else if (transform.parent.name == "Beer" && other.name == "Lighter")
            {
                //lighterAndBeer = false;
            }
            else if (transform.parent.name == "Beer" && other.name == "Turtle Egg")
            {
                collections.RemoveFromUnderwater("Strangled Turtle");
            }
            else if (transform.parent.name == "Beer" && other.name == "Plastic")
            {
                collections.RemoveFromBeach("Cooler");
            }

            //If gameObject is Lighter
            if (transform.parent.name == "Lighter" && other.name == "Wood")
            {
                woodAndLighter = false;
                collections.RemoveFromBeach("Bonfire");
            }
            else if (transform.parent.name == "Lighter" && other.name == "Beer")
            {
                //lighterAndBeer = false;
            }
            else if (transform.parent.name == "Lighter" && other.name == "Fish")
            {
                lighterAndFish = false;
            }

            //If gameObject is Turtle Egg
            if (transform.parent.name == "Turtle Egg" && other.name == "Beer")
            {
                collections.RemoveFromUnderwater("Strangled Turtle");
            }
            else if (transform.parent.name == "Turtle Egg" && other.name == "Turtle Egg")
            {
                collections.RemoveFromBeach("Turtle Hatch");
            }

            //If gameObject is CD
            if (transform.parent.name == "CD" && other.name == "Plastic")
            {
                plasticandCD = false;
            }
            else if (transform.parent.name == "CD" && other.name == "Metal")
            {
                cdandMetal = false;
            }
            else if (transform.parent.name == "CD" && other.name == "Wire")
            {
                wireAndCD = false;
            }
            else if (transform.parent.name == "CD" && other.name == "Metal")
            {
                metalandWire = false;
            }

            //If gameObject is Plastic (plastic box or container)
            if (transform.parent.name == "Plastic" && other.name == "CD")
            {
                plasticandCD = false;
            }
            else if (transform.parent.name == "Plastic" && other.name == "Metal")
            {
                metalandPlastic = false;
            }
            else if (transform.parent.name == "Plastic" && other.name == "Beer")
            {
                collections.RemoveFromBeach("Cooler");
            }

            //If gameObject is Metal
            if (transform.parent.name == "Metal" && other.name == "CD")
            {
                cdandMetal = false;
            }
            else if (transform.parent.name == "Metal" && other.name == "Plastic")
            {
                metalandPlastic = false;
            }
            else if (transform.parent.name == "Metal" && other.name == "Wire")
            {
                metalandWire = false;
            }

            //If gameObject is Glass
            if (transform.parent.name == "Glass" && other.name == "Fish")
            {
                collections.RemoveFromUnderwater("Aquarium");
            }

            //If gameObject is Wire
            else if (transform.parent.name == "Wire" && other.name == "Guitar")
            {
                collections.RemoveFromBeach("Guitar");
            }
            else if (transform.parent.name == "Wire" && other.name == "CD")
            {
                wireAndCD = false;
            }
            else if (transform.parent.name == "Wire" && other.name == "Metal")
            {
                metalandWire = false;
            }

        //3 Artifact Combos
        
        if ((!fishAndWood && !woodAndLighter) || (!lighterAndFish && !fishAndWood) || (!woodAndLighter && !lighterAndFish))
        {
            collections.RemoveFromBeach("Bonfire with Rack");
        }

        if ((!cdandMetal && !metalandPlastic) || (!plasticandCD && cdandMetal) || (!metalandPlastic && plasticandCD))
        {
            collections.RemoveFromBeach("Stereo");
        }

        if ((!cdandMetal && metalandWire) || (!wireAndCD && !cdandMetal) || (!metalandWire && !wireAndCD))
        {
            collections.RemoveFromBeach("Stereo");
        }

        /*
        //old bonfire
        if ((beerAndWood == false && woodAndLighter == false) || (lighterAndBeer == false && beerAndWood == false) || (woodAndLighter ==false && lighterAndBeer ==false))
            {
                collections.RemoveFromBeach("Bonfire");
            }
        */
    }

}
 