using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCheck : MonoBehaviour
{
    // instance
    public bool isInRange = false;

    
    /*
     * Check whether target stays in the collider.
     */
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            isInRange = true;
        }
    }

    
    /*
     * Check whether target is outside of the collider.
     */
    void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }

}
