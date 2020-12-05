using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveController : MonoBehaviour
{
    void OnCollisionEnter (Collision col)
    {

        Debug.Log("Collided with " + col.gameObject.name);
        if (col.gameObject.tag == "Cookables") {
            col.gameObject.GetComponent<CookingController>().Cook();
        }
    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("No longer in contact with " + col.gameObject.name);
        if (col.gameObject.tag == "Cookables") {
            col.gameObject.GetComponent<CookingController>().InterruptCook();
        }
    }
}
