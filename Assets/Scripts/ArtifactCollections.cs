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

    public bool overlapStarted;
    public LayerMask layerMask;
    
    void Start()
    {
        toUnderwaterWorld = GameObject.Find("PortalToUnderwater360");
        toBeachRecWorld = GameObject.Find("PortalToBeachRec360");

        toUnderwaterWorld.SetActive(false);
        toBeachRecWorld.SetActive(false);

        //overlapStarted = true;

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

                if (col.attachedRigidbody.isKinematic == false)
                {
                    StartCoroutine(KinematicCoroutine(col));
                }
            }

        }

    }
  
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Artifact") == true)
        {
            col.transform.parent = transform;
            col.transform.SetParent(transform);

            //Physics.IgnoreCollision(col.GetComponent<Collider>(), GetComponent<Collider>());
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
        }


    }
 

    IEnumerator KinematicCoroutine(Collider col)
    {
        yield return new WaitForSecondsRealtime(2);
        col.attachedRigidbody.isKinematic = true;

    }

    private void Update()
    {
        SearchForCollection();
    
        InstantiatePortal();

        //ArtifactsInPail();

      
    if (currentScene.name == "Tests 3D Gameworld Beach")
    {
        InstantiatePortal();
    }
   
    }
  
    /*
    void ArtifactsInPail()
    {
        //Use the OverlapBox to detect if there are any other colliders within this box area.
        //Use the GameObject's centre, half the size (as a radius) and rotation. This creates an invisible box around your GameObject.
        Collider[] artifactColliders = Physics.OverlapBox(gameObject.transform.position, transform.localScale / 2, Quaternion.identity, layerMask);
        int i = 0;
        //Check when there is a new collider coming into contact with the box
        while (i < artifactColliders.Length)
        {
            if (!collectedArtifacts.Contains(artifactColliders[i].gameObject))
            {
                //Output all of the collider names
                Debug.Log("Collected : " + artifactColliders[i].name + i);
                collectedArtifacts.Add(artifactColliders[i].gameObject);

            }
            //Increase the number of Colliders in the array
            i++;

        }
    }

    //Draw the Box Overlap as a gizmo to show where it currently is testing. Click the Gizmos button to see this
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        if (overlapStarted)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
    */
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
