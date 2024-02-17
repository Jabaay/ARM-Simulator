using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

        // Get Jammer position
        Vector3 jammerPos = GameObject.Find("Jammer").transform.position;

        // Target spawn postition
        // Make sure it won't collide with the Jammer
        Vector3[] targetSpawnPos = new Vector3[]
        {
            new Vector3(Random.Range(20f, jammerPos.x - 15f), Random.Range(-80f, jammerPos.y - 15f), 0), // left side under the jammer
            new Vector3(Random.Range(jammerPos.x + 15f, 242.4f), Random.Range(-80f, jammerPos.y - 15f), 0), // right side under the jammer
            new Vector3(Random.Range(20f, jammerPos.x - 15f), Random.Range(jammerPos.y + 15f, 0), 0), // left side above the jammer
            new Vector3(Random.Range(jammerPos.x + 15f, 242.4f), Random.Range(jammerPos.y + 15f, 0), 0) // right side above the jammer
        };

        transform.position = targetSpawnPos[Random.Range(0, targetSpawnPos.Length - 1)];
    }

}
