using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private Transform cameraPos;
    private Quaternion modifiedForY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(cameraPos, Vector3.up);
        if (Camera.main != null)
        {
            transform.LookAt(new Vector3(cameraPos.position.x, cameraPos.position.y / 2, cameraPos.position.z), Vector3.up);

        }
    }
    public void GetMainCamera()
    {
        cameraPos = Camera.main.transform;
    }
}
