using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Radar : MonoBehaviour
{

    [SerializeField] private bool active = true;
    //[SerializeField] private bool circular = true;
    [SerializeField] private float power = 2.0f; // The maximum output of the Jammer
    //[SerializeField] private float scale = 2.0f; // The distribution pattern of the jammer
    [SerializeField] private float radius = 30.0f; // The maximum radius of the Jammer
    // Maybe a field that allows the user to specify each jammer pulse

    private Vector3 decoyCoord = Vector3.zero; // Stores the decoy coordinate

    private void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
            radiate();

        //Debug.Log("JAMMER: " + getDecoyCoord());
    }

    // Method which holds the Radar implementation
    private void radiate()
    {
        // Jammer creates a list of Pairs, each pair containing the RNG output of
        // the Jammer and the coordinates at which it can be found.
        //      This rng is based on the Rayleigh distribution (Done?)
        //          For now cap the max value of RNG by power value (Done w/ Clamp)
        //      The coordinates must be within the radius (Done)
        // Please print to console or have some kind of graphical display (DONE)
        // Missile gets new target coords from new method in Jammer
        //      Jammer.getDecoyCoords()
        //      Returns the largest coordinate that is the closest to the
        //      missile.

        Vector3 radarPos = transform.position;

        // Create a list to store pairs of RNG values and their corresponding coordinates
        List<KeyValuePair<Vector3, float>> radarData = new List<KeyValuePair<Vector3, float>>();
        radarData = fillList(radarData, radarPos);

        findDecoyCoord(radarData);

        drawDecoyCoord();

    }

    private List<KeyValuePair<Vector3, float>> fillList(
        List<KeyValuePair<Vector3, float>> data, Vector3 jammerPos)
    {

        float minX = jammerPos.x - radius;
        float maxX = jammerPos.x + radius;

        float minY = jammerPos.y - radius;
        float maxY = jammerPos.y + radius;

        for (float y = minY; y <= maxY; y += 1)
        {
            for (float x = minX; x <= maxX; x += 1)
            {
                Vector3 jammingCoord = new Vector3(x, y, 0);
                //float distance = Vector3.Distance(jamPos, new Vector3(x, y, 0));

                if (Vector3.Distance(jammerPos, jammingCoord) >= radius)
                {
                    // Generate a random value based on the Rayleigh distribution
                    // Cap the jamming value by the power
                    // F(x; s) = 1 - e^(-x^2 / (2 * s^2))
                    //  s = scale,  x = power? 1 = constant
                    double u = UnityEngine.Random.value; // Get a uniform random number between 0 and 1
                    double stepA = 2.0 * Math.Pow(scale, 2.0); // Should this be randomly generated?
                    double stepB = Math.Pow(-u, 2.0) / stepA; // Should this be power?
                    float jammingValue = (float)(power - Math.Exp(stepB));
                    jammingValue = Math.Abs(jammingValue);
                    //jammingValue = Mathf.Clamp(jammingValue, 0, power);

                    // Store the jamming value and coordinates in the list
                    data.Add(new KeyValuePair<Vector3, float>(jammingValue, jammingCoord));
                }
            }
        }

        return data;
    }

    private void findDecoyCoord(List<KeyValuePair<Vector3, float>> jammingData)
    {
        //Vector3 jammerPos = transform.position;
        var max = jammingData[0];
        //var min = jammingData[0];

        foreach (var decPair in jammingData)
        {
            if (decPair.Key > max.Key)
                max = decPair;
            // else
            //     min = decPair;
        }

        decoyCoord = max.Value;
        //Debug.Log("\nMAX: " + max.Key + "\nPosition: " + max.Value +
        //    "\nMIN: " + min.Key + "\nPosition: " + min.Value);
    }

    private void drawDecoyCoord()
    {
        GameObject.Find("Circle").transform.position = getDecoyCoord();
    }

    public Vector3 getDecoyCoord()
    {
        return decoyCoord;
    }

    public bool getActive()
    {
        return active;
    }

    // Gizmo method, draws a circle to illustrate the radius of the Jammer
    // Meant to only work as a debug tool
    private void OnDrawGizmos()
    {
        if (active)
        {
            Vector3 jammerPos = transform.position;
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(jammerPos, radius);
        }
    }
}