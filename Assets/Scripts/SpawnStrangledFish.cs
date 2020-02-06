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
        //ground = GameObject.FindWithTag("Ground");

        if (ground != null)
        {
            underWaterCollections = ground.GetComponent<CollectionsIn360Scene>().underWaterCollections;

        }

    }
    // Update is called once per frame
    void Update()
    {
        if (underWaterCollections.Contains("Bonfire") == true && strangledFishPlaced == false)
        {
            strangledFishPlaced = true;
            strangled = Instantiate(StrangledFishPrefab);
            strangled.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        else if (strangledFishPlaced == true && underWaterCollections.Contains("Strangled Fish") == false)
        {
            Destroy(strangled);
        }
    }
}



