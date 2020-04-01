using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterSpawnManager : MonoBehaviour
{
    public GameObject ShipPrefab;
    public GameObject strangledFishPrefab;
    public GameObject strangledTurtlePrefab;
    public GameObject aquariumPrefab;

    GameObject ship;
    GameObject strangledFish;
    GameObject strangledTurtle;
    GameObject aquarium;

    public Transform shipSpawner;
    public Transform strangledFishSpawner;
    public Transform strangledTurtleSpawner;
    public Transform aquariumSpawner;

    public bool shipPlaced;
    public bool strangledFishPlaced;
    public bool strangledTurtlePlaced;
    public bool aquariumPlaced;

    public List<string> underWaterCollections = new List<string>();
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        shipSpawner.gameObject.GetComponent<MeshRenderer>().enabled = false;
        strangledFishSpawner.gameObject.GetComponent<MeshRenderer>().enabled = false;
        strangledTurtleSpawner.gameObject.GetComponent<MeshRenderer>().enabled = false;
        aquariumSpawner.gameObject.GetComponent<MeshRenderer>().enabled = false;


        if (ground != null)
        {

            underWaterCollections = ground.GetComponent<Collections>().underWaterCollections;

            //Sunken Ship Spawn
            ship = Instantiate(ShipPrefab);
            ship.SetActive(false);
            ship.transform.position = new Vector3(shipSpawner.position.x, shipSpawner.position.y, shipSpawner.position.z);

            //Strangled Fish Spawn
            strangledFish = Instantiate(strangledFishPrefab);
            strangledFish.SetActive(false);
            strangledFish.transform.position = new Vector3(strangledFishSpawner.position.x, strangledFishSpawner.position.y, strangledFishSpawner.position.z);

            //Strangled Turtle Spawn
            strangledTurtle = Instantiate(strangledTurtlePrefab);
            strangledTurtle.SetActive(false);
            strangledTurtle.transform.position = new Vector3(strangledTurtleSpawner.position.x, strangledTurtleSpawner.position.y, strangledTurtleSpawner.position.z);

            //Aquarium Spawn
            aquarium = Instantiate(aquariumPrefab);
            aquarium.SetActive(false);
            aquarium.transform.position = new Vector3(aquariumSpawner.position.x, aquariumSpawner.position.y, aquariumSpawner.position.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Sunken Ship Spawn
        if (underWaterCollections.Contains("Sunken Ship") == true && shipPlaced == false)
        {
            shipPlaced = true;
            ship.SetActive(true);

        }
        else if (shipPlaced == true && underWaterCollections.Contains("Sunken Ship") == false)
        {
            shipPlaced = false;
            ship.SetActive(false);

        }

        //Strangled Fish Spawn
        if (underWaterCollections.Contains("Strangled Fish") == true && strangledFishPlaced == false)
        {
            strangledFishPlaced = true;
            strangledFish.SetActive(true);
        }
        else if (strangledFishPlaced == true && underWaterCollections.Contains("Strangled Fish") == false)
        {
            strangledFishPlaced = false;
            strangledFish.SetActive(false);
        }

        //Strangled Turtle Spawn
        if (underWaterCollections.Contains("Strangled Turtle") == true && strangledTurtlePlaced == false)
        {
            strangledTurtlePlaced = true;
            strangledTurtle.SetActive(true);
        }
        else if (strangledTurtlePlaced == true && underWaterCollections.Contains("Strangled Turtle") == false)
        {
            strangledTurtlePlaced = false;
            strangledTurtle.SetActive(false);
        }

        //Aquarium Spawn
        if (underWaterCollections.Contains("Aquarium") == true && aquariumPlaced == false)
        {
            aquariumPlaced = true;
            aquarium.SetActive(true);
        }
        else if (aquariumPlaced == true && underWaterCollections.Contains("Aquarium") == false)
        {
            aquariumPlaced = false;
            aquarium.SetActive(false);
        }
    }
}
