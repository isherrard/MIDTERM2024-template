using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public Camera introCam;
    public Camera mainCam;
    public LookAtCamera lac;

    // Start is called before the first frame update
    void Start()
    {
        mainCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchCameras()
    {
        introCam.enabled = false;
        mainCam.enabled = true;
        lac.GetMainCamera();


}
}
