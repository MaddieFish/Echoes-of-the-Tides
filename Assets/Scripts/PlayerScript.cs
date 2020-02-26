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

    //public Vector2 joystick;


    public float moveSpeed = 5.0f;
    public float rotSpeed = 200.0f;
    public GameObject pObject;
    //public GameObject centreEye;



    public Rigidbody rb;

    //XR Controller Devuces
    public InputDevice LeftController;
    public InputDevice RightController;

    //Test Camera Rotation
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    //Toggle control types
    public bool xrController;
    public bool keyboardControls;
    public bool mouseCameraRotation;
    //public bool oculusControllerIntegration;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevices(inputDevices);

        foreach (var device in inputDevices)
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
            //Debug.Log(string.Format("Device found with name '{0}' and role '{1}'", device.name, deviceChar.ToString()));
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (xrController == true)
        {
            XRJoystickMOvement();
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

    void XRJoystickMOvement()
    {
        //Vector2 axisValues;

        RightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out axisValuesR);
        print(axisValuesR);

        LeftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out axisValuesL);
        print(axisValuesL);

        //transform.eulerAngles = new Vector3(0, centreEye.transform.localEulerAngles.y, 0);

        /*
        transform.Translate(Vector3.forward * moveSpeed * axisValues.y * Time.deltaTime);
        transform.Translate(Vector3.right * moveSpeed * axisValues.x * Time.deltaTime);

        pObject.transform.position = Vector3.Lerp(pObject.transform.position, transform.position, 10f * Time.deltaTime);
        */

        transform.Rotate(0, Input.GetAxis("axisValuesR") * Time.deltaTime * rotSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("axisValuesL") * Time.deltaTime * moveSpeed); 
         

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

        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);

    }

    void MouseCameraRotation()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}