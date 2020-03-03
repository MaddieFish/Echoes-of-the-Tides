using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collections : MonoBehaviour
{
    //Artifact collection lists
    public List<Transform> artifactsPlaced = new List<Transform>(); //Artifacts placed on ground
    public List<GameObject> artifacts = new List<GameObject>();
    public List<string> underWaterCollections = new List<string>();
    public List<string> beachRecCollections = new List<string>();

    //public float triggerDist;

    //Choose scene
    public bool underWaterScene;
    public bool beachRecScene;


    //2 combo collections
    public bool strangledFish = false;
    public bool sunkenShip = false;

    //3 combo collections
    public bool beerAndWood = false;
    public bool woodAndLighter = false;
    public bool lighterAndBeer = false;
    public bool bonfire = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Artifact") == true)
        {
            artifactsPlaced.Add(col.transform);
            artifacts.Add(col.gameObject);

            //print("You collected " + col.transform.name);
        }

    }
    void OnCollisionExit(Collision col)
    {
        artifactsPlaced.Remove(col.transform);
        artifacts.Remove(col.gameObject);
        //print("You removed the " + col.transform.name);
    }
    // Start is called before the first frame update

    public void AddToUnderwater(string underwaterObject)
    {
        if(!underWaterCollections.Contains(underwaterObject))
        {
            underWaterCollections.Add(underwaterObject);

        }
    }

    public void AddToBeach(string beachObject)
    {
        if (!beachRecCollections.Contains(beachObject)){
            underWaterCollections.Remove(beachObject);
        }

    }

    public void RemoveFromUnderwater(string underwaterObject)
    {
        if (underWaterCollections.Contains(underwaterObject))
        {
            underWaterCollections.Remove(underwaterObject);

        }
    }

    public void RemoveFromBeach(string beachObject)
    {
        if (beachRecCollections.Contains(beachObject))
        {
            beachRecCollections.Remove(beachObject);

        }
    }
}
