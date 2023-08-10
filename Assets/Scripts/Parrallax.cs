using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class parallaxBackground : MonoBehaviour
{
    float lenght;
    float startPosition;
    // [SerializeField] GameObject cam;
    [SerializeField] private Camera gameCamera;
    [FormerlySerializedAs("parallaxEffect")] [SerializeField] float parallaxEffectFactor;
    void Start()
    {
        startPosition = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        // Use if the background needs repetition (infinite scroll for example)
        // float temp = (gameCamera.transform.position.x * (1 - parallaxEffectFactor));
        // float dist = (gameCamera.transform.position.x * parallaxEffectFactor);
        // transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);
        // if (temp > startPosition + lenght)
        // {
        //   startPosition += lenght;
        // }
        // else if (temp < startPosition - lenght)
        // {
        //     startPosition -= lenght;
        // }

        float dist = (gameCamera.transform.position.x * parallaxEffectFactor);

        transform.position = new Vector3(startPosition + dist, transform.position.y, transform.position.z);
    }
}
