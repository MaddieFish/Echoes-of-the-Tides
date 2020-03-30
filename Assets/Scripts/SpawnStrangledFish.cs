using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStrangledFish : MonoBehaviour
{
    public GameObject StrangledFishPrefab;
    GameObject strangled;
    public List<string> underWaterCollections = new List<string>();
    public bool strangledFishPlaced;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //ground = GameObject.FindWithTag("Ground");

        if (ground != null)
        {
            //underWaterCollections = ground.GetComponent<CollectionsIn360Scene>().underWaterCollections;
            //underWaterCollections = ground.GetComponent<ArtifactProximity>().underWaterCollections;
            underWaterCollections = ground.GetComponent<Collections>().underWaterCollections;


            strangled = Instantiate(StrangledFishPrefab);
            strangled.SetActive(false);
            strangled.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }

    }
    // Update is called once per frame
    void Update()
    {
        if (underWaterCollections.Contains("Strangled Fish") == true && strangledFishPlaced == false)
        {
            strangledFishPlaced = true;
            strangled.SetActive(true);

            //strangled = Instantiate(StrangledFishPrefab);
            //strangled.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else if (strangledFishPlaced == true && underWaterCollections.Contains("Strangled Fish") == false)
        {
            //Destroy(strangled);
            strangledFishPlaced = false;
            strangled.SetActive(false);

        }
    }
}



