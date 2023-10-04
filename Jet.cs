using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jet : MonoBehaviour
{

    private float jetSpeed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {

        // starting position of the jet
        transform.position = new Vector3(-48.58f, 27.3f, 0); // comment out if using randomSpawn()

        // randomSpawn(); // call it here within Start()

    }


    // Update is called once per frame
    void Update()
    {

        // jet moves to the right until it disappears
        transform.Translate(Vector3.right * jetSpeed * Time.deltaTime);

    }


    /*
     * Takes care of random spawn positions.
     * For testing Turn() within the Missile class
     * DO NOT CALL OTHERWISE !!!
     */
    /*
    void randomSpawn()
    {
        float xPos = Random.Range(-49.5f, 42.5f);
        float yPos = Random.Range(-20.3f, 28.3f);
        transform.position = new Vector3(xPos, yPos, 0);
    }
    */


}
