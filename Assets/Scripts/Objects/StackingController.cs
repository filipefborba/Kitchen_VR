using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class StackingController : MonoBehaviour
// {
//     public BurguerController burguerController;

//     void Awake()
//     {
//         burguerController = GameObject.FindWithTag("Toast").GetComponent<BurguerController>();
//     }

//     void OnCollisionEnter(Collision col)
//     {
//         if ((col.gameObject.tag == "Toast") || (col.gameObject.tag == "Cookables"))
//         {
//             burguerController.SetChild(gameObject);
//         }
//     }
// }

public class StackingController : MonoBehaviour
{
    public BurguerController burguerController;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "FirstToast")
        {
            burguerController = col.gameObject.GetComponent<BurguerController>();
        }
        else if ((col.gameObject.tag) == "Cookables" && (col.gameObject.transform.parent != null))
        {
            burguerController = col.gameObject.GetComponent<StackingController>().burguerController;
            burguerController.SetChild(gameObject);
        }
        else if (col.gameObject.tag == "Toast")
        {
            burguerController.SetChild(col.gameObject);
        }
    }
}
