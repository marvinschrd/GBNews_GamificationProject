using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BirdScrolling : MonoBehaviour
{
    [SerializeField] private float movingSpeed;
    [SerializeField] private float maxXoffset;
    [SerializeField] private Transform startPosition;

    [SerializeField] private float maxTimerValue;
    [SerializeField] private float minTimerValue;
    private float timer;
    private float randomDelay;

    private bool resetBird = false;

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
        if (transform.position.x > startPosition.position.x + maxXoffset && !resetBird)
        {
            randomDelay = Random.Range(minTimerValue, maxTimerValue);
            timer = randomDelay;
            resetBird = true;
           // Debug.Log("reached offset");
        }

        if (resetBird)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
               // Debug.Log("timer at zero");
                float randYOffset = Random.Range(-2.0f, 3.0f);
                transform.position = new Vector3(startPosition.position.x, startPosition.position.y + randYOffset,
                    startPosition.position.z);

                resetBird = false;
            }
        }
       
    }
}
