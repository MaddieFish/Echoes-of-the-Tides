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

    public GameObject MainMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        freezePlayerMovement = true;
        MainMenu.SetActive(true);
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
}
