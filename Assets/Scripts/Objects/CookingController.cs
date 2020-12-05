using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingController : MonoBehaviour
{
    public float TimeToCook = 10f;
    public bool isCooking = false;
    public string status = "raw";
    private float cooked = 1f;
    private Renderer renderer;
    private MaterialPropertyBlock propBlock;
    public GameObject cookedMeat;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        propBlock = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_Intensity", 1f);
        renderer.SetPropertyBlock(propBlock);
    }

    void Update()
    {
        if (this.isCooking)
        {
            TimeToCook -= Time.deltaTime;

            if (TimeToCook <= 5.0f)
            {
                if (this.status != "done")
                {

                    CookReady();
                }
            }
            else if (TimeToCook <= 0.0f)
            {
                if (this.status == "done")
                {
                    CookEnd();
                }
            }
            renderer.GetPropertyBlock(propBlock);
            propBlock.SetFloat("_Intensity", this.TimeToCook / 10);
            renderer.SetPropertyBlock(propBlock);

        }
    }

    public void CookReady()
    {
        this.status = "cooked";
        Destroy(gameObject);
        GameObject cooked = Instantiate(cookedMeat, transform.position, Quaternion.identity) as GameObject;
        CookingController cookedCookingController = cooked.GetComponent<CookingController>();
        cookedCookingController.status = "done";
        cookedCookingController.TimeToCook = this.TimeToCook;
        cookedCookingController.isCooking = this.isCooking;

        // mudar o objeto pro legalzao =)
    }

    public void Cook()
    {
        Debug.Log("Started cooking");
        this.isCooking = true;
    }

    public void CookEnd()
    {
        this.status = "over";
        this.isCooking = false;
        renderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_Intensity", 0f);
        renderer.SetPropertyBlock(propBlock);

    }

    public void InterruptCook()
    {
        this.isCooking = false;
    }

}
