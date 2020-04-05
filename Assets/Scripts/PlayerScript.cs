//Reference: https://www.youtube.com/watch?v=moDKuF5ARh0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerScript : MonoBehaviour
{
    //Movement
    public Vector2 axisValuesR;
    public Vector2 axisValuesL;
  
    public bool yButton;
    public bool xButton;

    public float moveSpeed = 5.0f;
    public float rotSpeed = 200.0f;

    //XR Controller Devuces
    public InputDevice LeftController;
    public InputDevice RightController;

    //Test Camera Rotation
    public float speedMouseH = 2.0f;
    public float speedMouseV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    //Toggle control types
    public bool xrController;
    public bool keyboardControls;
    public bool mouseCameraRotation;

    public bool freezePlayerMovement;

    public GameObject menuScript;
    public bool collectionsList;


    // Start is called before the first frame update
    void Start()
    {
        InputDevices.deviceConnected += SetupControllers;

        //rb = GetComponent<Rigidbody>();
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
        {
            Debug.Log(device.name);
           
            if (device.characteristics.HasFlag(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left))
            {
                Debug.Log("Found Left Controller");
                LeftController = device;
            }

            if (device.characteristics.HasFlag(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right))
            {
                Debug.Log("Found Right Controller");
                RightController = device;
            }
            //Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, deviceChar.ToString()));
        }
    }
    private void SetupControllers(InputDevice device)
    {
        if (device.characteristics.HasFlag(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left))
        {
            Debug.Log("Found Left Controller");
            LeftController = device;
        }

        if (device.characteristics.HasFlag(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right))
        {
            Debug.Log("Found Right Controller");
            RightController = device;
        }
    }

    // Update is called once per frame
    void Update()
    {
        freezePlayerMovement = menuScript.GetComponent<UIManager>().freezePlayerMovement;
        collectionsList = menuScript.GetComponent<UIManager>().collectionOpen;

        if (freezePlayerMovement)
        {
            xrController = false;
            keyboardControls = false;
        } 
        else
        {
            xrController = true;
            keyboardControls = true;
        }

        if (xrController == true)
        {
            XRJoystickMovement();
        }

        if (keyboardControls == true)
        {
            KeyboardMovement();
        }

        
        if (mouseCameraRotation == true)
        {
            MouseCameraRotation();
        }
        
    }

    void XRJoystickMovement()
    {
        //Vector2 axisValues;

        RightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out axisValuesR);
        Debug.Log(axisValuesR);

        LeftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out axisValuesL);
        Debug.Log(axisValuesL);

        LeftController.TryGetFeatureValue(CommonUsages.primaryButton, out xButton);
        Debug.Log(xButton);

        LeftController.TryGetFeatureValue(CommonUsages.secondaryButton, out yButton);
        Debug.Log(yButton);

        /*
        var hLeftThumb = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal");
        var vLeftThumb = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical");
        var hRightThumb = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal");
        var vRightThumb = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical");
        */

        //transform.Rotate(0, axisValuesL.x * Time.deltaTime * rotSpeed, 0);
        //transform.Translate(0, 0, axisValuesL.y * Time.deltaTime * moveSpeed);
        //transform.Rotate(0, hLeftThumb * Time.deltaTime * rotSpeed, 0);
        //transform.Translate(0, 0, vLeftThumb * Time.deltaTime * moveSpeed);

        //transform.Rotate(0, axisValuesR.x * Time.deltaTime * rotSpeed, 0);
        transform.position = transform.position + Vector3.ProjectOnPlane((Camera.main.transform.forward * axisValuesL.y) * moveSpeed, Vector3.up);
        transform.position = transform.position + Vector3.ProjectOnPlane((Camera.main.transform.right * axisValuesL.x) * moveSpeed, Vector3.up);

        if (xButton)
        {
            menuScript.GetComponent<UIManager>().OpenMenu();
        }

        if (yButton)
        {
            menuScript.GetComponent<UIManager>().OpenCollectionList();
        }
        else if (yButton && collectionsList)
        {
            menuScript.GetComponent<UIManager>().CloseCollectionList();
        }

    }

    //For ingame testing without a headset
    void KeyboardMovement()
    {
        /*
        //Movement through force
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed); 
        rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed * Time.deltaTime); 
        */

        //Movement through transform
        //transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed)

        transform.Rotate(0, Input.GetAxis("HorizontalL") * Time.deltaTime * rotSpeed, 0);
        transform.position = transform.position + Vector3.ProjectOnPlane((Camera.main.transform.forward * Input.GetAxis("VerticalL")) * moveSpeed, Vector3.up);

        //transform.Translate(0, 0, Input.GetAxis("VerticalL") * Time.deltaTime * moveSpeed);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            menuScript.GetComponent<UIManager>().OpenMenu();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            menuScript.GetComponent<UIManager>().OpenCollectionList();
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && collectionsList)
        {
            menuScript.GetComponent<UIManager>().CloseCollectionList();
        }

    }

    void MouseCameraRotation()
    {
        yaw += speedMouseH * Input.GetAxis("Mouse X");
        pitch -= speedMouseV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= SetupControllers;
    }
}