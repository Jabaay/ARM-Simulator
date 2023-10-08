using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

[RequireComponent(typeof(Rigidbody2D))]
public class Radar : MonoBehaviour
{
    private Transform sweepTransform;
    private float rotationSpeed;
    private float radarDistance;
    private Rigidbody2D radar;
    public LayerMask detectableObjects; // A layer to determine which objects can be detected by the radar.

    void Start()
    {
        radar = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RotateSweep();
        DetectObjects();
    }

    private void Awake()
    {
        sweepTransform = transform.Find("Sweep");
        rotationSpeed = 180f;
        radarDistance = 150f;
    }

    private void RotateSweep()
    {
        sweepTransform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime); // Rotates the sweep around its forward axis.
    }

    private void DetectObjects()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(radar.position, radarDistance, detectableObjects);

        foreach (Collider2D obj in detectedObjects)
        {
            // Here, you can mark these objects on your radar UI or perform any action you want.
            Debug.Log("Detected object: " + obj.name);
        }
    }
}

