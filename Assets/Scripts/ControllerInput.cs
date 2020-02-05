using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ControllerInput : MonoBehaviour
{

    public InputDevice LeftController;
    public InputDevice RightController;

    // Start is called before the first frame update
    void Start()
    {
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
        Vector2 axisValues;
        RightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out axisValues);

        bool leftXButton;
        LeftController.TryGetFeatureValue(CommonUsages.primaryButton, out leftXButton);
        Debug.Log(leftXButton);
    }
}
