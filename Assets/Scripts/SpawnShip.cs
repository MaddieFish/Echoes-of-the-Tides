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
            underWaterCollections = ground.GetComponent<CollectionsIn360Scene>().underWaterCollections;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (underWaterCollections.Contains("Sunken Ship") == true && shipPlaced == false)
        {
            shipPlaced = true;
            ship = Instantiate(ShipPrefab);
            ship.transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z);
        }
        else if (shipPlaced == true && underWaterCollections.Contains("Sunken Ship") == false)
        {
            Destroy(ship);
        }
    }
}
