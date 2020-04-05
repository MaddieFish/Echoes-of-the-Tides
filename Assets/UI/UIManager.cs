using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public bool freezePlayerMovement = true;
    public bool collectionOpen;

    public GameObject MainMenu;
    public GameObject CollectionList;
    
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
}
