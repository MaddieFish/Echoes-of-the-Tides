//Reference for searching for specific objects in lists: 
//http://forum.brackeys.com/thread/check-if-a-list-contains-a-gameobject-with-a-specified-name/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtifactCollections : MonoBehaviour
{
    //List thet keeps track of artifacts in inventory
    public List<GameObject> collectedArtifacts = new List<GameObject>();
    public List<string> underwaterCollections = new List<string>();
    public List<string> beachRecCollections = new List<string>();


    //Artifact Collections
    public bool strangledFish = false;
    public bool bonfire = false;
    public bool sunkenShip = false;

    //Move to different script
    //public GameObject underwaterLocation;
    //public GameObject beachRecLocation;

    //public GameObject underwaterPortalPrefab;
    //public GameObject beachRecPortalPrefab;

    public GameObject toUnderwaterWorld;
    public GameObject toBeachRecWorld;
   

    public bool underwaterPortalIsCreated;
    public bool beachRecPortalIsCreated;

    Scene currentScene;

    //private Vector3 underwaterPosition = portalLocation1.transform.position;

    void Start()
    {
        toUnderwaterWorld = GameObject.Find("PortalToUnderwater360");
        toBeachRecWorld = GameObject.Find("PortalToBeachRec360");

        toUnderwaterWorld.SetActive(false);
        toBeachRecWorld.SetActive(false);

        //currentScene = SceneManager.GetActiveScene();
        //string activeScene = currentScene.name;
    }
    //Only objects tagged "Artifact" can be collected and added to list
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Artifact") == true)
        {
            collectedArtifacts.Add(col.gameObject);
            print("You collected " + col.transform.name);
            col.transform.parent = transform;
            col.transform.SetParent(transform);
            //col.attachedRigidbody.isKinematic = true;

        }

    }
    void OnTriggerExit(Collider col)
    {
        collectedArtifacts.Remove(col.gameObject);
        print("You removed the " + col.transform.name);
        //col.transform.parent = null;
        col.transform.SetParent(null);

        //col.attachedRigidbody.isKinematic = false;

    }

    private void Update()
    {
        SearchForCollection();
    
        InstantiatePortal();

        /*
    if (currentScene.name == "Tests 3D Gameworld Beach")
    {
        InstantiatePortal();
    }
    */
    }

    void SearchForCollection()
    {      
        
        //Check if fish + beer is in list
        strangledFish = collectedArtifacts.Any((GameObject) => GameObject.name == "Fish") && collectedArtifacts.Any((GameObject) => GameObject.name == "Beer");

        //Check if lighter + wood + beer is in list
        bonfire = collectedArtifacts.Any((GameObject) => GameObject.name == "Lighter") && collectedArtifacts.Any((GameObject) => GameObject.name == "Wood") && collectedArtifacts.Any((GameObject) => GameObject.name == "Beer");

        //Check if wood + fish is in list
        sunkenShip = collectedArtifacts.Any((GameObject) => GameObject.name == "Fish") && collectedArtifacts.Any((GameObject) => GameObject.name == "Wood");


        //Add completed collections and remove broken collections to related environmentCollection
        if (strangledFish == true && underwaterCollections.Contains("Strangled Fish") == false)
        {
            underwaterCollections.Add("Strangled Fish");
        }
        else if (strangledFish == false && underwaterCollections.Contains("Strangled Fish") == true)
        {
            underwaterCollections.Remove("Strangled Fish");
        }

        if (bonfire == true && beachRecCollections.Contains("Bonfire") == false)
        {
            beachRecCollections.Add("Bonfire");
        }
        else if (bonfire == false && beachRecCollections.Contains("Bonfire") == true)
        {
            beachRecCollections.Remove("Bonfire");
        }

        if (sunkenShip == true && underwaterCollections.Contains("Sunken Ship") == false)
        {
            underwaterCollections.Add("Sunken Ship");
        } 
        else if (sunkenShip == false && underwaterCollections.Contains("Sunken Ship") == true)
        {
            underwaterCollections.Remove("Sunken Ship");
        }
    }

    //Move to different script eventually
    void InstantiatePortal()
    {
        if (underwaterCollections.Count > 0 && !underwaterPortalIsCreated)
        {
            toUnderwaterWorld.SetActive(true);
            underwaterPortalIsCreated = true;
        }
        else if (underwaterCollections.Count == 0 && underwaterPortalIsCreated == true)
        {
            toUnderwaterWorld.SetActive(false);
            underwaterPortalIsCreated = false;
        }

        if (beachRecCollections.Count > 0 && !beachRecPortalIsCreated)
        {
            toBeachRecWorld.SetActive(true);
            beachRecPortalIsCreated = true;
        }
        else if (beachRecCollections.Count == 0 && beachRecPortalIsCreated == true)
        {
            toBeachRecWorld.SetActive(false);
            beachRecPortalIsCreated = false;
        }
    }
}

/*
void InstantiatePortal()
    {
        if (underwaterCollections.Count > 0 && !underwaterPortalIsCreated)
        {
            Instantiate(underwaterPortalPrefab).transform.position = new Vector3(underwaterLocation.transform.position.x, underwaterLocation.transform.position.y, underwaterLocation.transform.position.z);
            underwaterPortalIsCreated = true;
        }
        else if (underwaterCollections.Count == 0 && underwaterPortalIsCreated == true)
        {
            Destroy(Instantiate(underwaterPortalPrefab));
            underwaterPortalIsCreated = false;
        }

        if (beachRecCollections.Count > 0 && !beachRecPortalIsCreated)
        {
            Instantiate(beachRecPortalPrefab).transform.position = new Vector3(beachRecLocation.transform.position.x, beachRecLocation.transform.position.y, beachRecLocation.transform.position.z);
            beachRecPortalIsCreated = true;
        } 
        else if(beachRecCollections.Count == 0 && beachRecPortalIsCreated == true)
        {
            Destroy(Instantiate(beachRecPortalPrefab));
            beachRecPortalIsCreated = false;
        }
    }
    */
