using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{

    // some instances for calculation
    [Range(0, 78)]  public float radius = 20; // radius of FOV, ranging from 0 to 78 (current camera width)
    [Range(1, 179)] public float angle = 45; // angle of FOV, ranging from 1 to 179, default is 45
    Vector2 circleOrigin; // origin position of FOV
    private float powerReceivedRatio1; // in the direction of ememy radar
    private float powerReceivedRatio2; // in the direction of current trajectory



    // Start is called before the first frame update
    void Start()
    {
        OnDrawGizmos();
        Instances();
    }



    // Update is called once per frame
    private void Update()
    {
        
    }


    /*
     * Gets the calculations done.
     */
    private void Instances()
    {
        powerReceivedRatio1 = 1 / Mathf.Pow(radius, 2);
        powerReceivedRatio2 = powerReceivedRatio1 * 1 / Mathf.Pow(2 * radius * Mathf.Sin(angle / 2), 2);
    }



    /*
     * Draws a circle on the screen with a pre-defined radius.
     */
    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.white;

        circleOrigin = new Vector2(transform.position.x + 7f, transform.position.y);

        UnityEditor.Handles.DrawWireDisc(circleOrigin, Vector3.forward, radius);

        Vector3 angle1 = DirectionFromAngle(-transform.eulerAngles.z, -angle / 2 + 90);
        Vector3 angle2 = DirectionFromAngle(-transform.eulerAngles.z, angle / 2 + 90);

        Vector3 startPos1 = transform.position + transform.right * 7f;
        Vector3 startPos2 = transform.position + transform.right * 7f;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(startPos1, startPos1 + angle1 * radius);
        Gizmos.DrawLine(startPos2, startPos2 + angle2 * radius);

    }



    /*
     * 
     */
    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }


}
