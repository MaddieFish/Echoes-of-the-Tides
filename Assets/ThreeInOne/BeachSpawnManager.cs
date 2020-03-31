using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach Script to WorldManager GameObject
public class BeachSpawnManager : MonoBehaviour
{
    public GameObject bonfirePrefab;
    public GameObject bonfireWithRackPrefab;
    public GameObject coolerPrefab;
    public GameObject guitarPrefab;
    public GameObject stereoPrefab;
    public GameObject turtleHatchPrefab;

    GameObject bonfire;
    GameObject bonfireWithRack;
    GameObject cooler;
    GameObject guitar;
    GameObject stereo;
    GameObject turtleHatch;

    public Transform bonfireSpawner;
    public Transform bonfireWithRackSpawner;
    public Transform coolerSpawner;
    public Transform guitarSpawner;
    public Transform stereoSpawner;
    public Transform turtleHatchSpawner;

    public bool bonfirePlaced;
    public bool bonfireWithRackPlaced;
    public bool coolerPlaced;
    public bool guitarPlaced;
    public bool stereoPlaced;
    public bool turtleHatchPlaced;

    public List<string> beachRecCollections = new List<string>();
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        bonfireSpawner.gameObject.GetComponent<MeshRenderer>().enabled = false;
        bonfireWithRackSpawner.gameObject.GetComponent<MeshRenderer>().enabled = false;
        coolerSpawner.gameObject.GetComponent<MeshRenderer>().enabled = false;
        guitarSpawner.gameObject.GetComponent<MeshRenderer>().enabled = false;
        stereoSpawner.gameObject.GetComponent<MeshRenderer>().enabled = false;
        turtleHatchSpawner.gameObject.GetComponent<MeshRenderer>().enabled = false;

        if (ground != null)
        {
            beachRecCollections = ground.GetComponent<Collections>().beachRecCollections;

            //Bonfire Spawn
            bonfire = Instantiate(bonfirePrefab);
            bonfire.SetActive(false);
            bonfire.transform.position = new Vector3(bonfireSpawner.position.x, bonfireSpawner.position.y, bonfireSpawner.position.z);

            //Bonfire with Rack Spawn
            bonfireWithRack = Instantiate(bonfireWithRackPrefab);
            bonfireWithRack.SetActive(false);
            bonfireWithRack.transform.position = new Vector3(bonfireWithRackSpawner.position.x, bonfireWithRackSpawner.position.y, bonfireWithRackSpawner.position.z);

            //Cooler Spawn
            cooler = Instantiate(coolerPrefab);
            cooler.SetActive(false);
            cooler.transform.position = new Vector3(coolerSpawner.position.x, coolerSpawner.position.y, coolerSpawner.position.z);

            //Guitar Spawn
            guitar = Instantiate(guitarPrefab);
            guitar.SetActive(false);
            guitar.transform.position = new Vector3(guitarSpawner.position.x, guitarSpawner.position.y, guitarSpawner.position.z);

            //Stereo Spawn
            stereo = Instantiate(stereoPrefab);
            stereo.SetActive(false);
            stereo.transform.position = new Vector3(stereoSpawner.position.x, stereoSpawner.position.y, stereoSpawner.position.z);

            //Stereo Spawn
            turtleHatch = Instantiate(turtleHatchPrefab);
            turtleHatch.SetActive(false);
            turtleHatch.transform.position = new Vector3(turtleHatchSpawner.position.x, turtleHatchSpawner.position.y, turtleHatchSpawner.position.z);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Bonfire Spawn
        if (beachRecCollections.Contains("Bonfire") == true && bonfirePlaced == false)
        {
            bonfirePlaced = true;
            bonfire.SetActive(true);
        }
        else if (bonfirePlaced == true && beachRecCollections.Contains("Bonfire") == false)
        {
            bonfirePlaced = false;
            bonfire.SetActive(false);
        }

        //Bonfire with Rack Spawn
        if (beachRecCollections.Contains("Bonfire with Rack") == true && bonfireWithRackPlaced == false)
        {
            bonfireWithRackPlaced = true;
            bonfireWithRack.SetActive(true);
        }
        else if (bonfireWithRackPlaced == true && beachRecCollections.Contains("Bonfire with Rack") == false)
        {
            bonfireWithRackPlaced = false;
            bonfireWithRack.SetActive(false);
        }

        //Cooler Spawn
        if (beachRecCollections.Contains("Cooler") == true && coolerPlaced == false)
        {
            coolerPlaced = true;
            cooler.SetActive(true);
        }
        else if (cooler == true && beachRecCollections.Contains("Cooler") == false)
        {
            coolerPlaced = false;
            cooler.SetActive(false);
        }

        //Guitar Spawn
        if (beachRecCollections.Contains("Guitar") == true && guitarPlaced == false)
        {
            guitarPlaced = true;
            guitar.SetActive(true);
        }
        else if (guitarPlaced == true && beachRecCollections.Contains("Guitar") == false)
        {
            guitarPlaced = false;
            guitar.SetActive(false);
        }

        //Stereo Spawn
        if (beachRecCollections.Contains("Stereo") == true && stereoPlaced == false)
        {
            stereoPlaced = true;
            stereo.SetActive(true);
        }
        else if (stereoPlaced == true && beachRecCollections.Contains("Stereo") == false)
        {
            stereoPlaced = false;
            stereo.SetActive(false);
        }

        //Turtle Hatch Spawn
        if (beachRecCollections.Contains("Turtle Hatch") == true && turtleHatchPlaced == false)
        {
            turtleHatchPlaced = true;
            turtleHatch.SetActive(true);
        }
        else if (turtleHatchPlaced == true && beachRecCollections.Contains("Turtle Hatch") == false)
        {
            turtleHatchPlaced = false;
            turtleHatch.SetActive(false);
        }
    }
}
