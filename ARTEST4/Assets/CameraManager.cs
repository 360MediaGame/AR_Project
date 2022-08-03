using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject ARSession;
    public GameObject ARSessionOrigin;

    public void CameraOnOFF_Change()
    {
        if (ARSession.activeSelf == true)
        {
            ARSession.SetActive(false);
            ARSessionOrigin.SetActive(false);
        }
        else
        {
            ARSession.SetActive(true);
            ARSessionOrigin.SetActive(true);
        }
    }

}
