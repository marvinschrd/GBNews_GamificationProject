using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloudsScrolling : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    [SerializeField] private float maxXoffset;
    [SerializeField] private Transform startPosition;

    private Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position =
            new Vector3(transform.position.x + 0.01f * movingSpeed, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > startPosition.position.x + maxXoffset)
        {
            float randYOffset = Random.Range(-1.0f, 1.0f);
            transform.position = new Vector3(startPosition.position.x, startPosition.position.y + randYOffset,
                startPosition.position.z);
        }
    }
}
