using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVSetting : MonoBehaviour
{
    // script communication
    public FOVSlider fovSlider; 

    // instances of FOV
    protected float radius;
    protected float angle;

    private float newX;
    private float newY;


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
    }


    // Configure collider's shape with points
    private void setColliderPoints()
        {
            // Get the PolygonCollider2D component attached to your GameObject
            PolygonCollider2D polygonCollider = gameObject.GetComponent<PolygonCollider2D>();

            // Define the points for the collider
            int pathIndex = 0;

            Vector2[] pathPoints = new Vector2[]
            {
                new Vector2(newX, newY), // first point
                new Vector2(newX, -newY), // second point
                new Vector2(0, 0), // third point, fixed
            };

            // Update the path in the Polygon Collider
            polygonCollider.SetPath(pathIndex, pathPoints);
        }

}


