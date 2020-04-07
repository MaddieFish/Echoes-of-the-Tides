using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;

public class UIManager : MonoBehaviour
{
    public bool freezePlayerMovement = true;
    public bool collectionOpen = false;

    public GameObject MainMenu;
    public GameObject CollectionList;

    public GameObject UnderwaterArtifacts1;
    //public GameObject UnderwaterArtifacts2;
    public GameObject BeachRecArtifacts1;
    //public GameObject BeachRecArtifacts2;

    public GameObject KinematicPail;
    public GameObject GrabbablePail;

    public Toggle toggleCollections;
    public Toggle togglePail;

    public GameObject underwaterGround;
    public GameObject beachDayGround;

    public List<GameObject> beachArtifacts;
    public List<GameObject> underwaterArtifacts;
    public List<GameObject> existingArtifacts;

    public List<Transform> beachArtifactsTran;
    public List<Transform> underwaterArtifactsTran;

    // Start is called before the first frame update
    void Start()
    {
        freezePlayerMovement = true;
        MainMenu.SetActive(true);
        CollectionList.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        beachArtifacts = beachDayGround.GetComponent<Collections>().artifacts;
        underwaterArtifacts = underwaterGround.GetComponent<Collections>().artifacts;

        beachArtifactsTran = beachDayGround.GetComponent<Collections>().artifactsPlaced;
        underwaterArtifactsTran = underwaterGround.GetComponent<Collections>().artifactsPlaced;
    }

    public void StartExperience()
    {
        freezePlayerMovement = false;
        MainMenu.SetActive(false);
    }

    public void QuitApplication()
    {
         Application.Quit();
        print("Application Quit...");
    }

    public void OpenMenu()
    {
        MainMenu.SetActive(true);
        freezePlayerMovement = true;
    }

    public void OpenCollectionList()
    {
        CollectionList.SetActive(true);
        collectionOpen = true;
    }

    public void CloseCollectionList()
    {
        CollectionList.SetActive(false);
        collectionOpen = false;
    }

    public void CompleteAllCollections()
    {
        if (toggleCollections.isOn == true)
        {
            UnderwaterArtifacts1.SetActive(true);
            BeachRecArtifacts1.SetActive(true);
            //UnderwaterArtifacts2.SetActive(true);
            //BeachRecArtifacts2.SetActive(true);

        } 
        else
        {

            UnderwaterArtifacts1.SetActive(false);
            BeachRecArtifacts1.SetActive(false);
            //UnderwaterArtifacts2.SetActive(false);
            //BeachRecArtifacts2.SetActive(false);

            //beachArtifacts.Clear();
            //beachArtifactsTran.Clear();

            //underwaterArtifacts.Clear();
            //underwaterArtifactsTran.Clear();

            beachDayGround.GetComponent<Collections>().removeCompleteCollections();
            underwaterGround.GetComponent<Collections>().removeCompleteCollections();

            existingArtifacts = GameObject.FindGameObjectsWithTag("Artifact").ToList();

            foreach (GameObject artifact in existingArtifacts)
            {
                if (!artifact.activeSelf)
                {
                    existingArtifacts.Remove(artifact);
                }
                else
                {
                    artifact.transform.Translate(0, 0.05f, 0);

                }
            }

            //StartCoroutine(ExecuteAfterTime(2));

        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay

        
    }

    public void SwitchPailSettings()
    {
        if (togglePail.isOn == true)
        {
            KinematicPail.SetActive(true);
            GrabbablePail.SetActive(false);
        }
        else
        {
            KinematicPail.SetActive(false);
           GrabbablePail.SetActive(true);
        }
    }


}
