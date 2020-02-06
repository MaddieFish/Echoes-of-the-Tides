//Reference for searching for specific objects in lists: 
//http://forum.brackeys.com/thread/check-if-a-list-contains-a-gameobject-with-a-specified-name/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
    public GameObject underwaterLocation;
    public GameObject beachRecLocation;

    public GameObject underwaterPortalPrefab;
    public GameObject beachRecPortalPrefab;

    public bool underwaterPortalIsCreated;
    public bool beachRecPortalIsCreated;

    //private Vector3 underwaterPosition = portalLocation1.transform.position;


    //Only objects tagged "Artifact" can be collected and added to list
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Artifact") == true)
        {
            collectedArtifacts.Add(col.gameObject);
            print("You collected " + col.transform.name);
            col.transform.parent = transform;
            //col.attachedRigidbody.isKinematic = true;

        }

    }
    void OnTriggerExit(Collider col)
    {
        collectedArtifacts.Remove(col.gameObject);
        print("You removed the " + col.transform.name);
        col.transform.parent = null;
        //col.attachedRigidbody.isKinematic = false;

    }

    private void Update()
    {
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
        if (underwaterCollections.Count > 0 && !underwaterPortalIsCreated)
        {
            Instantiate(underwaterPortalPrefab).transform.position = new Vector3(underwaterLocation.transform.position.x, underwaterLocation.transform.position.y, underwaterLocation.transform.position.z);
            underwaterPortalIsCreated = true;
        }
        else if (underwaterCollections.Count == 1 && underwaterPortalIsCreated == true)
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
}
