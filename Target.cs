using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(
            Random.Range(0, 242.4f),
            Random.Range(-72.6f, 0),
            0);
    }

   

}
