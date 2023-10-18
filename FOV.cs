using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{

    // some instances for calculation
    [Range(0, 78)]  public float radius = 30; // radius of FOV, ranging from 0 to 78 (current camera width)
    [Range(1, 179)] public float angle = 45; // angle of FOV, ranging from 1 to 179 degrees
    Vector2 circleOrigin; // origin position of FOV

    private float powerReceivedRatio1; // in the direction of ememy radar
    private float powerReceivedRatio2; // in the direction of current trajectory

    public bool canSeeTarget { get; private set; } // get is public while set is private 

    public LayerMask targetLayer;
    public LayerMask obstructionLayer;

    public GameObject targetRef;


    // Start is called before the first frame update
    void Start()
    {
        // find the target by tag, or you can just use FindGameObject()
        targetRef = GameObject.FindGameObjectWithTag("Target"); // adjust as needed
        StartCoroutine(FOVCheck());
    }


    // Update is called once per frame
    private void Update()
    {

    }


    /*
     * FOV updates every 0.2 seconds.
     */
    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f); // adjust as needed

        while (true)
        {
            yield return wait;
            FieldOfView();
        }
    }

    /*
     * Checks whether the target is in the FOV range.
     */
    private void FieldOfView()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.right, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                    canSeeTarget = true;
                else
                    canSeeTarget = false;
            }
            else
                canSeeTarget = false;
        }
        else if (canSeeTarget)
            canSeeTarget = false;
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
