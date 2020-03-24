//Reference for cycling through items in list: 
//https://answers.unity.com/questions/535634/regarding-simple-inventorycycle-through-items-with.html
//https://answers.unity.com/questions/1354376/cycle-through-objects-on-mouse-click.html
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySelection : MonoBehaviour
{
    public Transform artifactSpawner;

    public List<GameObject> collectedArtifacts;

    public GameObject currentItem;
    public GameObject passedItem;

    public int _currentItemIndex = 0;
    public int index;


    // Start is called before the first frame update
    void Start()
    {
        if (currentItem != null)
        {
            _currentItemIndex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        collectedArtifacts = gameObject.GetComponentInChildren<ArtifactCollections>().collectedArtifacts;
        if (collectedArtifacts.Count == 1)
        {
            print("objects in bucket");
            currentItem = collectedArtifacts[0];
            _currentItemIndex = 0;
        }
        if (collectedArtifacts.Count > 0)
        {
          

            if (Input.GetKeyDown("a"))
            {
                //? is to THEN, : is to ELSE
                // IF _currentItemIndex > 0 IS TRUE THEN index EQUALS _currentItemIndex - 1 ELSE collectedArtifacts.Count - 1.

                //previous item
                index = _currentItemIndex > 0 ? _currentItemIndex - 1 : collectedArtifacts.Count - 1;
                passedItem = currentItem;
                SelectItem(index);
                //DeselectItem(index);
                print("cycled back");
            } 
            else if (Input.GetKeyDown("d"))
            {
                //next item
                passedItem = currentItem;
                 index = _currentItemIndex == collectedArtifacts.Count - 1 ? 0 : _currentItemIndex + 1;
                SelectItem(index);
                //DeselectItem(index);
                print("cycled forward");

            }

        }
    }

    private void SelectItem(int index)
    {
        if (index == _currentItemIndex)
        {
            return;
        }
        currentItem = collectedArtifacts[index];
        _currentItemIndex = index;

        //spawn current object
        currentItem.transform.position = artifactSpawner.position;
        currentItem.SetActive(true);

        //remove passed object
        passedItem.transform.position = artifactSpawner.position;
        passedItem.SetActive(false);
    }

}
