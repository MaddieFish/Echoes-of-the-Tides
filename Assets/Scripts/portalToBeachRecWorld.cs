using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portalToBeachRecWorld : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") == true)
        {


            StartCoroutine(LoadYourAsyncScene());


        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player") == true)
        {

        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("360 Beach Recreation", LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName("360 Beach Recreation"));

        spawnLocation = GameObject.Find("PlayerSpawner");

        player.transform.position = new Vector3(spawnLocation.transform.position.x, spawnLocation.transform.position.y, spawnLocation.transform.position.z);

        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);


    }
}
