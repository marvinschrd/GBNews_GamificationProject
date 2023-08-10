using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using FixedUpdate = UnityEngine.PlayerLoop.FixedUpdate;

public class CameraMovement : MonoBehaviour
{
    private Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = gameObject.transform;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var position = cameraTransform.position;
            position = new Vector3(position.x + 0.2f, position.y,position.z);
            cameraTransform.position = position;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            var position = cameraTransform.position;
            position = new Vector3(position.x - 0.2f, position.y,position.z);
            cameraTransform.position = position;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
