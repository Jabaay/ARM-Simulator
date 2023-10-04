using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    // the following instances are subject to change by the user
    [SerializeField] private float speed = 14.5f; // traveling speed of the missile horizontal to its trajectory
    [SerializeField] private float boost = 1.0f; // boosting speed of the missile perpendicular to its trajectory
    [SerializeField] private float angle; // angle of initial motion

    private float xPos; // current x position of the missile
    private float yPos; // current y position of the missile

    private float sumSpeed; // vector sum of the missile's traveling and boosting speed
    private float maxDistance; // max distance the missile needs to travel to hit the target
    private float maxTravelTime;// max time the missile needs to hit the target
    private float totalDistance; // total distance the missile needs to travel to hit the target
    private float horizontalDistance; // horizontal distance the missile needs to travel to hit the target
    private float verticalDistance; // vertical distance the missile needs to travel to hit the target
    // private float travelTime; // time the missile needs to hit the target



    // Start is called before the first frame update
    void Start()
    {

        // using distance formula to do the calculations
        // horizontal bound is (-48.6, 50.22)
        // vertical bound is (-25.83, 27.3)
        sumSpeed = Mathf.Sqrt(Mathf.Pow(speed, 2) + Mathf.Pow(boost, 2));
        maxDistance = Mathf.Sqrt(Mathf.Pow((-48.6f - 50.22f), 2) + Mathf.Pow((27.3f + 25.83f), 2));
        maxTravelTime = maxDistance / sumSpeed;

    }



    // Update is called once per frame
    void Update()
    {

        // get missile's current position by frame
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        xPos = transform.position.x;
        yPos = transform.position.y;

        // get the distance b/t the missile and target by frame
        horizontalDistance = xPos - 50.22f;
        verticalDistance = yPos + 25.83f;
        totalDistance = Mathf.Sqrt(Mathf.Pow(horizontalDistance, 2) + Mathf.Pow(verticalDistance, 2));
        // travelTime = totalDistance / sumSpeed;

        // method call
        InitialTrajectory();
        IfTurn();
        // Collision(); // No need to implement now
    }



    /*
     * Initial trajectory of the missile moving in a straight line.
     */
    private void InitialTrajectory()
    {
        // initial trajectory of the missile
        transform.Translate(Vector3.right * speed * Time.deltaTime); // horizontal 
        transform.Translate(Vector3.down * boost * Time.deltaTime); // vertical

        // intial traveling angle of the missile
        angle = Mathf.Atan2(boost, speed);
        angle *= 180 / Mathf.PI; // convert the angle from radian to degree

        // rotate the misile by the initial angle
        transform.rotation = Quaternion.Euler(0, 0, -angle);
    }



    /*
     * Adjusts the missile's trajectory towards the target.
     */
    private void Turn()
    {
        // CURRENTLY WORKING ON IT !!!
        // METHOD STILL NEED FIXING !!!

        // a fixed angle for capping the turning angles
        // calculated by the inverse tangent of the vertical distance between the missile and target, over the horizontal distance between the two
        // convert from radian to degree, same as before
        // targert location is (49.68, -25.09)
        float fixedAngle = Mathf.Atan2((transform.position.x - 49.68f), (transform.position.y + 25.09f)) * 180 / Mathf.PI;

        // 3 random angles for adjusting the missile's trajectory, less than fixedAngle
        float turningAngle1 = Random.Range(0, fixedAngle);
        float turningAngle2 = Random.Range(0, fixedAngle - turningAngle1);
        float turningAngle3 = Random.Range(0, fixedAngle - turningAngle1 - turningAngle2);
        // float[] turningAngles = { turningAngle1, turningAngle2, turningAngle3 };

        // first turn
        if (totalDistance <= maxDistance / 3)
        {
            transform.rotation = Quaternion.Euler(0, 0, -turningAngle1);
        }

        // second turn
        else if (totalDistance <= maxDistance * 2 / 3)
        {
            transform.rotation = Quaternion.Euler(0, 0, -turningAngle2);
        }

        // third turn
        else if (totalDistance <= maxDistance)
        {
            transform.rotation = Quaternion.Euler(0, 0, -turningAngle3);
        }

    }



    /*
     * Determines whether the missile needs to make turns to hit the target.
     */
    private void IfTurn()
    {

        float hitTime; // determines whether the missile travels faster horizontally or vertically 

        // if it travels faster horizontally 
        if (horizontalDistance / speed >= verticalDistance / boost)
        {
            hitTime = horizontalDistance / speed;
        }

        // if vertically 
        else
        {
            hitTime = verticalDistance / boost;
        }


        // if the missile is going out of bounds before hitting the target, make a turn
        if (hitTime * speed + transform.position.x > 50.22
                || hitTime * boost + transform.position.y > 27.3)
        {
            Turn();
        }

        // else do nothing
        else
        {

        }
    }



    /*
     * Determines when the missile needs to make a turn.
     *
     */
    /*
    private void when2Turn()
    {

        // WORK IN PROGRESS, DON'T CALL !!!

        // 3 random unit time intervals between each adjustments
        float unitTime1 = Random.Range(0, maxTravelTime); // 1st adjustment
        float unitTime2 = Random.Range(0, maxTravelTime - unitTime1); // 2nd adjustment
        float unitTime3 = Random.Range(0, maxTravelTime - unitTime1 - unitTime2); // 3rd adjustment
        // float[] unitTimes = { unitTime1, unitTime2, unitTime3 };

    }
    */



    /*
     * Takes care of collisions.
     */
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Incomplete, DON'T MODIFY!!!
        if (collision.CompareTag("Missile"))
        {
            if (collision.transform.parent != null)
            {
                Destroy(collision.transform.parent.gameObject);
            } 
            else
            {
                Destroy(collision.gameObject);
            }
        }
        
    }
    */



}
