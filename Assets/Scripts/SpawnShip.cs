using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShip : MonoBehaviour
{
    public GameObject ShipPrefab;
    GameObject ship;
    public List<string> underWaterCollections = new List<string>();
    public bool shipPlaced;
    public GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        //ground = GameObject.FindWithTag("Ground");

        if (ground != null)
        {
            //underWaterCollections = ground.GetComponent<CollectionsIn360Scene>().underWaterCollections;
            //underWaterCollections = ground.GetComponent<ArtifactProximity>().underWaterCollections;
            underWaterCollections = ground.GetComponent<Collections>().underWaterCollections;


            ship = Instantiate(ShipPrefab);
            ship.SetActive(false);
            ship.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (underWaterCollections.Contains("Sunken Ship") == true && shipPlaced == false)
        {
            shipPlaced = true;
            ship.SetActive(true);

            //ship = Instantiate(ShipPrefab);
            //ship.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else if (shipPlaced == true && underWaterCollections.Contains("Sunken Ship") == false)
        {
            shipPlaced = false;
            ship.SetActive(false);

        }
    }
}
