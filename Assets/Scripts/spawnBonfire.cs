using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBonfire : MonoBehaviour
{
    public GameObject BonfirePrefab;
    GameObject bonfire;
    public List<string> beachRecCollections = new List<string>();
    public bool bonfirePlaced;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        //ground = GameObject.FindWithTag("Ground");

        if (ground != null)
        {
            //beachRecCollections = ground.GetComponent<CollectionsIn360Scene>().beachRecCollections;
            //beachRecCollections = ground.GetComponent<ArtifactProximity>().beachRecCollections;
            beachRecCollections = ground.GetComponent<Collections>().beachRecCollections;


            bonfire = Instantiate(BonfirePrefab);
            bonfire.SetActive(false);
            bonfire.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }
    }
        // Update is called once per frame
    void Update()
        {
         if (beachRecCollections.Contains("Bonfire") == true && bonfirePlaced == false)
         {
            bonfirePlaced = true;
            bonfire.SetActive(true);

            //bonfire = Instantiate(BonfirePrefab);
            //bonfire.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else if (bonfirePlaced == true && beachRecCollections.Contains("Bonfire")==false)
         {
            bonfirePlaced = false;
            bonfire.SetActive(false);
        }
    }
}
