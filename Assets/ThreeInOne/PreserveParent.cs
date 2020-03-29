//On selection by XR interactor child grabbable objects selected get unparented

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveParent : MonoBehaviour
{
    public Transform grab;

    private float offset = 0.578f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(grab.position.x, grab.position.y - offset, grab.position.z);
    }
}
