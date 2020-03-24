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

    //Inventory Spawner
    public Transform artifactSpawner;

    //Artifact Collections
    public bool strangledFish = false;
    public bool bonfire = false;
    public bool sunkenShip = false;

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


