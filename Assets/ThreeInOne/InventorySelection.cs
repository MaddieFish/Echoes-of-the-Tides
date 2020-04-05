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

    public GameObject inventoryUI;
    public GameObject arrowLeftUI;
    public GameObject arrowRightUI;

    public bool enableCycle;

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
        //collectedArtifacts = gameObject.GetComponentInChildren<ArtifactCollections>().collectedArtifacts;
        collectedArtifacts = gameObject.GetComponent<ArtifactCollections>().collectedArtifacts;

        if (collectedArtifacts.Count == 1)
        {
            print("objects in bucket");
            currentItem = collectedArtifacts[0];
            _currentItemIndex = 0;
        }

        if (collectedArtifacts.Count > 0)
        {
            var hAxisKey = Input.GetAxisRaw("HorizontalR");
            var hAxisThumb = Input.GetAxisRaw("Oculus_CrossPlatform_SecondaryThumbstickHorizontal");

            print(hAxisKey + ", " + hAxisThumb);

            if (enableCycle)
            {
                //if (Input.GetKeyDown("a"))
                if (hAxisKey < -0.19 || hAxisThumb < -0.19)
                {
                    //? is to THEN, : is to ELSE
                    // IF _currentItemIndex > 0 IS TRUE THEN index EQUALS _currentItemIndex - 1 ELSE collectedArtifacts.Count - 1.

                    //previous item
                    index = _currentItemIndex > 0 ? _currentItemIndex - 1 : collectedArtifacts.Count - 1;
                    passedItem = currentItem;
                    SelectItem(index);
                    //DeselectItem(index);

                    arrowLeftUI.GetComponent<ButtonImageSwitch>().OnSelect();

                    print("cycled back");
                    //Input.ResetInputAxes();
                    StartCoroutine("DelayCoroutine");

                }
                //else if (Input.GetKeyDown("d"))
                else if (hAxisKey > 0.19 || hAxisThumb > 0.19)
                {
                    //next item
                    passedItem = currentItem;
                    index = _currentItemIndex == collectedArtifacts.Count - 1 ? 0 : _currentItemIndex + 1;
                    SelectItem(index);
                    //DeselectItem(index);

                    arrowRightUI.GetComponent<ButtonImageSwitch>().OnSelect();

                    print("cycled forward");
                    StartCoroutine("DelayCoroutine");
                }
                else
                {
                    arrowLeftUI.GetComponent<ButtonImageSwitch>().OnDeselect();
                    arrowRightUI.GetComponent<ButtonImageSwitch>().OnDeselect();
                }
            }
        }
    }

    IEnumerator DelayCoroutine()
    {
        Input.ResetInputAxes();
        yield return new WaitForSecondsRealtime(1);
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

    public void EnableCycleThroughInventory()
    {
        enableCycle = true;
        inventoryUI.SetActive(true);
    }

    public void DisableCycleThroughInventory()
    {
        enableCycle = false;
        inventoryUI.SetActive(false);
    }

}
