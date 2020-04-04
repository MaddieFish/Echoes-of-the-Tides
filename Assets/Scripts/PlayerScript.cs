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


    public float moveSpeed = 5.0f;
    public float rotSpeed = 200.0f;
    //public GameObject pObject;
    //public GameObject centreEye;



    //public Rigidbody rb;

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

        /*
        var hLeftThumb = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal");
        var vLeftThumb = Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical");
        var hRightThumb = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal");
        var vRightThumb = Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical");
        */

        //transform.Rotate(0, axisValuesL.x * Time.deltaTime * rotSpeed, 0);
        //transform.Translate(0, 0, axisValuesL.y * Time.deltaTime * moveSpeed);

        //transform.Rotate(0, axisValuesR.x * Time.deltaTime * rotSpeed, 0);
        transform.position = transform.position + Vector3.ProjectOnPlane((Camera.main.transform.forward * axisValuesL.y) * moveSpeed, Vector3.up);
        transform.position = transform.position + Vector3.ProjectOnPlane((Camera.main.transform.right * axisValuesL.x) * moveSpeed, Vector3.up);

        //transform.Rotate(0, hLeftThumb * Time.deltaTime * rotSpeed, 0);
        //transform.Translate(0, 0, vLeftThumb * Time.deltaTime * moveSpeed);


        //transform.Translate(-Camera.main.transform.right * moveSpeed * vLeftThumb * Time.deltaTime);

        //transform.Translate(-Camera.main.transform.right * moveSpeed * axisValuesL.y * Time.deltaTime);

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