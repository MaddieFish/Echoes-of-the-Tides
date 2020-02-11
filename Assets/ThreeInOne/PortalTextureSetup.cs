//Reference: Brackeys Smooth Portals in Unity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera Underwater360Camera;
    public Material CameraMat_Underwater;

    public Camera BeachGameWorldCameraUnderwater;
    public Material CameraMat_BeachGameWorldUnderwater;

    public Camera BeachRec360Camera;
    public Material CameraMat_BeachRec;

    public Camera BeachGameWorldCameraRec;
    public Material CameraMat_BeachGameWorldRec;


    // Start is called before the first frame update
    void Start()
    {
        if (Underwater360Camera.targetTexture != null)
        {
            Underwater360Camera.targetTexture.Release();
        }
        Underwater360Camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMat_Underwater.mainTexture = Underwater360Camera.targetTexture;

        if (BeachGameWorldCameraUnderwater.targetTexture != null)
        {
            BeachGameWorldCameraUnderwater.targetTexture.Release();
        }
        BeachGameWorldCameraUnderwater.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMat_BeachGameWorldUnderwater.mainTexture = BeachGameWorldCameraUnderwater.targetTexture;


        if (BeachRec360Camera.targetTexture != null)
        {
            BeachRec360Camera.targetTexture.Release();
        }
        BeachRec360Camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMat_BeachRec.mainTexture = BeachRec360Camera.targetTexture;

        if (BeachGameWorldCameraRec.targetTexture != null)
        {
            BeachGameWorldCameraRec.targetTexture.Release();
        }
        BeachGameWorldCameraRec.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMat_BeachGameWorldRec.mainTexture = BeachGameWorldCameraRec.targetTexture;
    }

}
