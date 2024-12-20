using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(shake());
    }

    IEnumerator shake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)UnityEngine.Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        transform.position = initialPosition;   
        
    }
}
