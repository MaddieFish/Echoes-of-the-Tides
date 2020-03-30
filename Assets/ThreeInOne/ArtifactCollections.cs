//Reference for searching for specific objects in lists: 
//http://forum.brackeys.com/thread/check-if-a-list-contains-a-gameobject-with-a-specified-name/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

//Attach script to pail GamObject that contains trigger collider
//Keeps track of all artifacts collect and possible collections that can be fulfilled

public class ArtifactCollections : MonoBehaviour
{
    //List thet keeps track of artifacts in inventory
    public List<GameObject> collectedArtifacts = new List<GameObject>();
    public List<string> underwaterCollections = new List<string>();
    public List<string> beachRecCollections = new List<string>();

    //Inventory Spawner
    public Transform artifactSpawner;

    //Artifact Collections
    public bool strangledFish = false;
    public bool strangledTurtle;
    public bool sunkenShip = false;
    public bool aquarium;

    public bool bonfire = false;
    public bool guitar;
    public bool cooler;

    public bool bonfireWithRack;
    public bool stereo;


    public GameObject toUnderwaterWorld;
    public GameObject toBeachRecWorld;

    public GameObject currentItem;

    public bool underwaterPortalIsCreated;
    public bool beachRecPortalIsCreated;

    Scene currentScene;
    
    void Start()
    {
        toUnderwaterWorld = GameObject.Find("PortalToUnderwater360");
        toBeachRecWorld = GameObject.Find("PortalToBeachRec360");

        if (toUnderwaterWorld != null && toBeachRecWorld != null)
        {
            toUnderwaterWorld.SetActive(false);
            toBeachRecWorld.SetActive(false);
        }

        //currentScene = SceneManager.GetActiveScene();
        //string activeScene = currentScene.name;
    }

    //Only objects tagged "Artifact" can be collected and added to list
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Artifact") == true)
        {
            if (!collectedArtifacts.Contains(col.gameObject)){
                collectedArtifacts.Add(col.gameObject);
                print("You collected " + col.transform.name);

                col.transform.parent = transform;
                col.transform.SetParent(transform);

                col.transform.position = artifactSpawner.position;

                if (col.attachedRigidbody.isKinematic == false)
                {
                    col.attachedRigidbody.isKinematic = true;

                    //StartCoroutine(KinematicCoroutine(col));
                }

                ArtifactInventoryToggle(col);

            }

        }

    }
  
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Artifact") == true)
        {
            col.transform.parent = transform;
            col.transform.SetParent(transform);

            //col.transform.position = artifactSpawner.position;

            //Physics.IgnoreCollision(col.GetComponent<Collider>(), GetComponent<Collider>());

            //ArtifactInventoryToggle(col);
        }

    }
 
    
    void OnTriggerExit(Collider col)
    {
        if (collectedArtifacts.Contains(col.gameObject))
        {
            collectedArtifacts.Remove(col.gameObject);
            print("You removed the " + col.transform.name);
            col.transform.parent = null;
            col.transform.SetParent(null);

            col.attachedRigidbody.isKinematic = false;

            //col.gameObject.SetActive(true);

        }


    }
 
    void ArtifactInventoryToggle(Collider col)
    {
        if (currentItem != null && col.gameObject != currentItem)
        {
            col.gameObject.SetActive(false);
        }
        else
        {
            col.gameObject.SetActive(true);

        }
    }

    IEnumerator KinematicCoroutine(Collider col)
    {
        yield return new WaitForSecondsRealtime(2);
        col.attachedRigidbody.isKinematic = true;
    }

    private void Update()
    {
        currentItem = gameObject.GetComponentInParent<InventorySelection>().currentItem;

        SearchForCollection();
    
        InstantiatePortal();
    }

void SearchForCollection()
    {      
        
        //Check if fish + beer is in list
        strangledFish = collectedArtifacts.Any((GameObject) => GameObject.name == "Fish") && collectedArtifacts.Any((GameObject) => GameObject.name == "Beer");

        //Check if turtle egg + beer is in list
        strangledTurtle = collectedArtifacts.Any((GameObject) => GameObject.name == "Turtle Egg") && collectedArtifacts.Any((GameObject) => GameObject.name == "Beer");
       
        //Check if wood + fish is in list
        sunkenShip = collectedArtifacts.Any((GameObject) => GameObject.name == "Fish") && collectedArtifacts.Any((GameObject) => GameObject.name == "Wood");

        //Check if fish + glass is in list
        aquarium = collectedArtifacts.Any((GameObject) => GameObject.name == "Fish") && collectedArtifacts.Any((GameObject) => GameObject.name == "Glass");

        //Check if wood + lighter is in list
        bonfire = collectedArtifacts.Any((GameObject) => GameObject.name == "Wood") && collectedArtifacts.Any((GameObject) => GameObject.name == "Lighter");

        //Check if wood + wire is in list
        guitar = collectedArtifacts.Any((GameObject) => GameObject.name == "Wood") && collectedArtifacts.Any((GameObject) => GameObject.name == "Wire");

        //Check if plastic + beer is in list
        cooler = collectedArtifacts.Any((GameObject) => GameObject.name == "Plastic") && collectedArtifacts.Any((GameObject) => GameObject.name == "Beer");

        //Check if lighter + wood + fish is in list
        bonfireWithRack = collectedArtifacts.Any((GameObject) => GameObject.name == "Lighter") && collectedArtifacts.Any((GameObject) => GameObject.name == "Wood") && collectedArtifacts.Any((GameObject) => GameObject.name == "Fish");

        //Check if CD + wire + metal is in list
        stereo = collectedArtifacts.Any((GameObject) => GameObject.name == "CD") && collectedArtifacts.Any((GameObject) => GameObject.name == "Wire") && collectedArtifacts.Any((GameObject) => GameObject.name == "Metal");

        //Check if CD + plastic + metal is in list
        stereo = collectedArtifacts.Any((GameObject) => GameObject.name == "CD") && collectedArtifacts.Any((GameObject) => GameObject.name == "Plastic") && collectedArtifacts.Any((GameObject) => GameObject.name == "Metal");

        //Check if lighter + wood + beer is in list
        //bonfire = collectedArtifacts.Any((GameObject) => GameObject.name == "Lighter") && collectedArtifacts.Any((GameObject) => GameObject.name == "Wood") && collectedArtifacts.Any((GameObject) => GameObject.name == "Beer");

        //Add completed collections and remove broken collections to related environmentCollection
        if (strangledFish == true && underwaterCollections.Contains("Strangled Fish") == false)
        {
            underwaterCollections.Add("Strangled Fish");
        }
        else if (strangledFish == false && underwaterCollections.Contains("Strangled Fish") == true)
        {
            underwaterCollections.Remove("Strangled Fish");
        }

        if (strangledTurtle == true && underwaterCollections.Contains("Strangled Turtle") == false)
        {
            underwaterCollections.Add("Strangled Turtle");
        }
        else if (strangledTurtle == false && underwaterCollections.Contains("Strangled Turtle") == true)
        {
            underwaterCollections.Remove("Strangled Turtle");
        }

        if (sunkenShip == true && underwaterCollections.Contains("Sunken Ship") == false)
        {
            underwaterCollections.Add("Sunken Ship");
        }
        else if (sunkenShip == false && underwaterCollections.Contains("Sunken Ship") == true)
        {
            underwaterCollections.Remove("Sunken Ship");
        }

        if (aquarium == true && underwaterCollections.Contains("Aquarium") == false)
        {
            underwaterCollections.Add("Aquarium");
        }
        else if (aquarium == false && underwaterCollections.Contains("Aquarium") == true)
        {
            underwaterCollections.Remove("Aquarium");
        }

        if (bonfire == true && beachRecCollections.Contains("Bonfire") == false)
        {
            beachRecCollections.Add("Bonfire");
        }
        else if (bonfire == false && beachRecCollections.Contains("Bonfire") == true)
        {
            beachRecCollections.Remove("Bonfire");
        }

        if (guitar == true && beachRecCollections.Contains("Guitar") == false)
        {
            beachRecCollections.Add("Guitar");
        }
        else if (guitar == false && beachRecCollections.Contains("Guitar") == true)
        {
            beachRecCollections.Remove("Guitar");
        }

        if (cooler == true && beachRecCollections.Contains("Cooler") == false)
        {
            beachRecCollections.Add("Cooler");
        }
        else if (cooler == false && beachRecCollections.Contains("Cooler") == true)
        {
            beachRecCollections.Remove("Cooler");
        }

        if (bonfireWithRack == true && beachRecCollections.Contains("Bonfire with Rack") == false)
        {
            beachRecCollections.Add("Bonfire with Rack");
        }
        else if (bonfireWithRack == false && beachRecCollections.Contains("Bonfire with Rack") == true)
        {
            beachRecCollections.Remove("Bonfire with Rack");
        }

        if (stereo == true && beachRecCollections.Contains("Stereo") == false)
        {
            beachRecCollections.Add("Stereo");
        }
        else if (stereo == false && beachRecCollections.Contains("Stereo") == true)
        {
            beachRecCollections.Remove("Stereo");
        }
    }

    //Move to different script eventually
    void InstantiatePortal()
    {

        if (underwaterCollections.Count > 0 && !underwaterPortalIsCreated && toUnderwaterWorld != null)
        {
            toUnderwaterWorld.SetActive(true);
            underwaterPortalIsCreated = true;
        }
        else if (underwaterCollections.Count == 0 && underwaterPortalIsCreated)
        {
            toUnderwaterWorld.SetActive(false);
            underwaterPortalIsCreated = false;
        }

        if (beachRecCollections.Count > 0 && !beachRecPortalIsCreated && toBeachRecWorld != null)
        {
            toBeachRecWorld.SetActive(true);
            beachRecPortalIsCreated = true;
        }
        else if (beachRecCollections.Count == 0 && beachRecPortalIsCreated)
        {
            toBeachRecWorld.SetActive(false);
            beachRecPortalIsCreated = false;
        }
    }
}


