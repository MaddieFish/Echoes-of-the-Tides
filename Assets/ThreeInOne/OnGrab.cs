using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OnGrab : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody rigidbody;
    // Start is called before the first frame update

    void Awake()
    {
        rigidbody = GetComponent< Rigidbody > ();
        grabInteractable = GetComponent<XRGrabInteractable>();


    }

    public void RemoveFromInvent()
    {
        rigidbody.isKinematic = false;
        grabInteractable.gameObject.transform.parent = null;
        grabInteractable.gameObject.transform.SetParent(null);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
