//Reference: https://www.youtube.com/watch?v=moDKuF5ARh0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Movement
    public Vector2 joystick;
    public float moveSpeed = 5.0f;
    public float rotSpeed = 200.0f;
    public GameObject centreEye;
    public GameObject pObject;

    public Rigidbody rb;

    //Test Camera Rotation
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    //Toggle control types
    public bool VRController;

    public bool keyboardControls;
    public bool mouseCameraRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VRController == true)
        {
            OculusJoystickMovement();
        }

        if(keyboardControls == true)
        {
            KeyboardMovement();
        }

        if (mouseCameraRotation == true)
        {
            MouseCameraRotation();
        }

    }

    void OculusJoystickMovement()
    {
        //Joystick input for Oculus Rift (prob including Oculus Quest)
        joystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        transform.eulerAngles = new Vector3(0, centreEye.transform.localEulerAngles.y, 0);
        transform.Translate(Vector3.forward * moveSpeed * joystick.y * Time.deltaTime);
        transform.Translate(Vector3.right * moveSpeed * joystick.x * Time.deltaTime);

        pObject.transform.position = Vector3.Lerp(pObject.transform.position, transform.position, 10f * Time
            .deltaTime);
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
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);

        /*
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * rotSpeed, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed);
        */
    }

    void MouseCameraRotation()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

}
