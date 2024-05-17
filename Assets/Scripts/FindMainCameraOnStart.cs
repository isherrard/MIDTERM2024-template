using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMainCameraOnStart : MonoBehaviour
{
    public LookAtCamera[] lac;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < lac.Length; i++)
        {
            lac[i].GetMainCamera();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
