using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using FixedUpdate = UnityEngine.PlayerLoop.FixedUpdate;
using Vector3 = UnityEngine.Vector3;

public class CameraMovement : MonoBehaviour
{
    private bool moveTotarget = false;
    private Vector3 targetPosition;
    private Transform cameraTransform;

    [SerializeField] private float movementSPeed = 1.0f;
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

    public void moveTo(Vector3 position)
    {
        targetPosition = position;
        moveTotarget = true;
    }

    //Update is called once per frame
    void Update()
    {
        if (moveTotarget)
        {
            Vector3 position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movementSPeed);
            transform.position = position;
            if (Vector3.Distance(transform.position, targetPosition) <= 0.1)
            {
                moveTotarget = false;
            }
        }
        
    }
}
