using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public bool spawn = true;
    public GameObject salad;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Debugzin()
    {
        if (this.spawn)
        {
            GameObject salad_instance = Instantiate(salad, transform.position, Quaternion.Euler(90, 0, 0)) as GameObject;
            salad_instance.GetComponent<Rigidbody>().isKinematic = false;
            this.spawn = false;
        }
    }
}
