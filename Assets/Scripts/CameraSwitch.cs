using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public GameObject arCam;
    public GameObject otaCam;
    public Text btnText;
    private bool camFlag = true;
    void Start()
    {
        arCam.SetActive(true);
        otaCam.SetActive(false);
        btnText.text = "AR CAM";
    }

    public void camSwitch()
    {
        if (camFlag)
        {
            arCam.SetActive(false);
            otaCam.SetActive(true);
            camFlag = false;
            btnText.text = "OTA CAM";
        }
        else
        {
            arCam.SetActive(true);
            otaCam.SetActive(false);
            camFlag = true;
            btnText.text = "AR CAM";
        }
    }


}
