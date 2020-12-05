using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurguerController : MonoBehaviour
{
    public GameObject burguer;
    private List<string> childrenNames = new List<string>();

    public void SetChild(GameObject child)
    {
        // Debug.Log("Child object: " + child.name);

        if (transform.childCount == 0)
        {
            gameObject.tag = "FirstToast";
        }

        child.transform.parent = this.transform;

        // Check if there is another bread on top to finish burguer
        foreach (Transform c in transform)
        {
            if (c.tag == "Toast")
            {
                DestroyAndCreateBurguer();
            }
        }

        // Debug.Log(child.name + " Parent is now " + child.transform.parent.name);
    }

    public void DetachFromParent(GameObject child)
    {
        // Debug.Log(child.name + " Parent was " + child.transform.parent.name);
        child.transform.parent = null;

        if (transform.childCount == 0)
        {
            gameObject.tag = "Toast";
        }
    }

    void OnCollisionEnter(Collision col)
    {
        // Debug.Log("BurguerController Collided with " + col.gameObject.name);
        if (col.gameObject.tag == "Cookables" && col.gameObject.transform.parent == null)
        {
            SetChild(col.gameObject);
        }
    }

    void OnCollisionExit(Collision col)
    {
        Debug.Log("BurguerController No longer in contact with " + col.gameObject.name);
        if (col.gameObject.tag == "Cookables")
        {
            DetachFromParent(col.gameObject);
        }
    }

    void DestroyAndCreateBurguer()
    {
        foreach (Transform child in transform)
        {
            childrenNames.Add(child.name);
        }
        // foreach (string a in childrenNames)
        // {
        //     Debug.Log(a);
        // }
        Destroy(gameObject);
        Instantiate(burguer, transform.position, Quaternion.identity);
        // Instantiate burguer blablabla
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BurguerController : MonoBehaviour
// {

//     public Dictionary<string, bool> childs = new Dictionary<string, bool>();

//     public void SetChild(GameObject child)
//     {
//         Debug.Log("Child object: " + child.name);

//         child.transform.parent = this.transform;

//         Debug.Log(child.name + " Parent is now " + child.transform.parent.name);

//         // Check if the new parent has a parent GameObject.
//         // if (newChild.transform.parent != null)
//         // {
//         //     //Display the name of the grand parent of the player.
//         //     Debug.Log("Player's Grand parent: " + player.transform.parent.parent.name);
//         // }
//     }

//     public void DetachFromParent(GameObject child)
//     {
//         Debug.Log(child.name + " Parent was " + child.transform.parent.name);
//         // Detaches the transform from its parent.
//         child.transform.parent = null;
//     }

//     void OnTriggerStay(Collider col)
//     {


//         if (col.gameObject.tag == "Cookables")
//         {
//             SetChild(col.gameObject);
//             if (childs.ContainsKey(col.gameObject.name))
//             {
//                 Debug.Log(childs[col.gameObject.name]);
//                 if (childs[col.gameObject.name] != true)
//                 {

//                     childs[col.gameObject.name] = true;
//                     SetChild(col.gameObject);

//                 }
//             }
//             else
//             {
//                 childs.Add(col.gameObject.name, true);
//                 SetChild(col.gameObject);
//             }
//         }

//     }

//     void OnTriggerExit(Collider col)
//     {
//         if (col.gameObject.tag == "Cookables")
//         {
//             if (childs.ContainsKey(col.gameObject.name))
//             {
//                 if (childs[col.gameObject.name] == true)
//                 {
//                     childs[col.gameObject.name] = false;
//                     DetachFromParent(col.gameObject);

//                 }
//             }
//             else
//             {
//                 //childs.Add(col.gameObject.name, false);
//                 DetachFromParent(col.gameObject);
//             }
//         }
//     }
// }













