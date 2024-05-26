using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    private Camera SkyCamera;
    public Vector3 skyboxRotation;

    // Start is called before the first frame update
    void Start()
    {
        SkyCamera = GameObject.Find("Skybox Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        SkyCamera.transform.Rotate(skyboxRotation * Time.deltaTime);
    }
}
