using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVSetting : MonoBehaviour
{
    // script communication
    public FOVSlider fovSlider; 

    // instances of FOV
    private float radius;
    private float angle;
    private float newX;
    private float newY;

    private PolygonCollider2D pc;
    private LineRenderer lr;


    // Start is called before the first frame
    private void Start()
    {
        pc = GetComponent<PolygonCollider2D>();
        lr = GetComponent<LineRenderer>();

        lr.loop = true;
        lr.startWidth = 0.15f; // start width
        lr.endWidth = 0.15f; // end width
        // lr.startColor = new Color(144, 238, 144); // start color
        // lr.endColor = new Color(144, 238, 144); // end color
    }


    // Update is called on every frame
    void Update()
    {
        // Get the values from the corresponding sliders
        radius = fovSlider._radiusSlider.value;
        angle = fovSlider._angleSlider.value * Mathf.PI / 180; // degree to radian conversion

        // Compute x and y from radius and angle
        newX = radius * Mathf.Abs(Mathf.Cos(angle));
        newY = radius * Mathf.Abs(Mathf.Sin(angle));

        setColliderPoints(); // call setColliderPoints()
        updateLineRenderer(); // update lr
    }


    // Configure collider's shape with points
    private void setColliderPoints()
    {
        // Get the PolygonCollider2D component attached to your GameObject
        PolygonCollider2D polygonCollider = gameObject.GetComponent<PolygonCollider2D>();

        Vector2[] pathPoints = new Vector2[]
        {
            new Vector2(newX, newY), // first point
            new Vector2(newX, -newY), // second point
            new Vector2(0, 0), // third point, fixed
        };

        // Update the path in the Polygon Collider
        polygonCollider.SetPath(0, pathPoints);
    }


    // Update line renderer to match with polygon collider
    private void updateLineRenderer()
    {
        if (lr)
        {
            // Get the points 
            Vector2[] colliderPoints = pc.GetPath(0);
            Vector3[] linePositions = new Vector3[colliderPoints.Length];

            for (int i = 0; i < colliderPoints.Length; i++)
            {
                Vector3 worldPoint = transform.TransformPoint(colliderPoints[i]);
                linePositions[i] = new Vector3(worldPoint.x + 6.55f, worldPoint.y, 0f);
            }

            // Set line renderer positions
            lr.positionCount = linePositions.Length;
            lr.SetPositions(linePositions);
        }
    }

}


