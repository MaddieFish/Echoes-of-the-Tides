using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsUIManager : MonoBehaviour
{
    public GameObject beachRecGround;
    public GameObject underWaterGround;
    public List<string> underWaterCollections;
    public List<string> beachRecCollections;

    //Artifact Images
    public GameObject strangledFish;
    public GameObject strangledFishStandIn;

    public GameObject strangledTurtle;
    public GameObject strangledTurtleStandIn;

    public GameObject shipwreck;
    public GameObject shipwreckStandIn;

    public GameObject aquarium;
    public GameObject aquariumStandIn;

    public GameObject guitar;
    public GameObject guitarStandIn;

    public GameObject turtleHatch;
    public GameObject turtleHatchStandIn;

    public GameObject cooler;
    public GameObject coolerStandIn;

    public GameObject bonfire;
    public GameObject bonfireStandIn;

    public GameObject bonfireRack;
    public GameObject bonfireRackStandIn;

    public GameObject stereoV1;
    public GameObject stereoV1StandIn;

    public GameObject stereoV2;
    public GameObject stereoV2StandIn;


    // Start is called before the first frame update
    void Start()
    {
        beachRecCollections = beachRecGround.GetComponent<Collections>().beachRecCollections;
        underWaterCollections = underWaterGround.GetComponent<Collections>().underWaterCollections;

    }

    // Update is called once per frame
    void Update()
    {
        if (underWaterCollections.Contains("Strangled Fish"))
        {
            strangledFish.SetActive(true);
            strangledFishStandIn.SetActive(false);
        }
        else
        {
            strangledFish.SetActive(false);
            strangledFishStandIn.SetActive(true);
        }

        if (underWaterCollections.Contains("Strangled Turtle"))
        {
            strangledTurtle.SetActive(true);
            strangledTurtleStandIn.SetActive(false);
        }
        else
        {
            strangledTurtle.SetActive(false);
            strangledTurtleStandIn.SetActive(true);
        }

        if (underWaterCollections.Contains("Sunken Ship"))
        {
            shipwreck.SetActive(true);
            shipwreckStandIn.SetActive(false);
        }
        else
        {
            shipwreck.SetActive(false);
            shipwreckStandIn.SetActive(true);
        }

        if (underWaterCollections.Contains("Aquarium"))
        {
            aquarium.SetActive(true);
            aquariumStandIn.SetActive(false);
        }
        else
        {
            aquarium.SetActive(false);
            aquariumStandIn.SetActive(true);
        }

        if (beachRecCollections.Contains("Guitar"))
        {
            guitar.SetActive(true);
            guitarStandIn.SetActive(false);
        }
        else
        {
            guitar.SetActive(false);
            guitarStandIn.SetActive(true);
        }

        if (beachRecCollections.Contains("Turtle Hatch"))
        {
            turtleHatch.SetActive(true);
            turtleHatchStandIn.SetActive(false);
        }

        else
        {
            turtleHatch.SetActive(false);
            turtleHatchStandIn.SetActive(true);
        }

        if (beachRecCollections.Contains("Cooler"))
        {
            cooler.SetActive(true);
            coolerStandIn.SetActive(false);
        }

        else
        {
            cooler.SetActive(false);
            coolerStandIn.SetActive(true);
        }

        if (beachRecCollections.Contains("Bonfire"))
        {
            bonfire.SetActive(true);
            bonfireStandIn.SetActive(false);
        }

        else
        {
            bonfire.SetActive(false);
            bonfireStandIn.SetActive(true);
        }

        if (beachRecCollections.Contains("Bonfire with Rack"))
        {
            bonfireRack.SetActive(true);
            bonfireRackStandIn.SetActive(false);
        }

        else
        {
            bonfireRack.SetActive(false);
            bonfireRackStandIn.SetActive(true);
        }

        if (beachRecCollections.Contains("StereoV1"))
        {
            stereoV1.SetActive(true);
            stereoV1StandIn.SetActive(false);
        }

        else
        {
            stereoV1.SetActive(false);
            stereoV1StandIn.SetActive(true);
        }

        if (beachRecCollections.Contains("StereoV2"))
        {
            stereoV2.SetActive(true);
            stereoV2StandIn.SetActive(false);
        }

        else
        {
            stereoV2.SetActive(false);
            stereoV2StandIn.SetActive(true);
        }
    }
}
