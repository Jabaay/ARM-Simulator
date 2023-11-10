using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Missile : MonoBehaviour
{

    private Rigidbody2D body;
    public Jammer jammer;
    public RangeCheck rc;
    public SpeedSlider ss;

    [SerializeField] private float speed; // traveling speed of the missile horizontal to its trajectory
    [SerializeField] private float boost; // boosting speed of the missile perpendicular to its trajectory
    //[SerializeField] private float angle; // angle of initial motion

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {

        // get speed and boost updated
        speed = ss._speedSlider.value;
        boost = ss._boostSlider.value;


        Vector2 targetPos;

        if (jammer != null && jammer.getActive())
        {
            //Debug.Log("MISSILE: " + jammer.getDecoyCoord());
            targetPos = jammer.getDecoyCoord();
        }
        else
            targetPos = GameObject.Find("Target").transform.position;

        Vector2 direction = targetPos - body.position;
        direction.Normalize();

        body.velocity = transform.right * speed;
        // The missile stop tracking if it passes target
        if (body.position.x < targetPos.x && rc.isInRange)
        {
            float rotateAmount = Vector3.Cross(direction, transform.right).z;
            body.angularVelocity = -rotateAmount * boost;
        }
        // If the missile misses
        else
        {
            body.velocity = transform.right * speed;
            body.angularVelocity = 0;
        }
    }
}
