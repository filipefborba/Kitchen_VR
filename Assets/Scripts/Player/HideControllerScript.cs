using UnityEngine;
using System;
using Valve.VR.InteractionSystem.Sample;
public class HideControllerScript : MonoBehaviour
{
    void LateUpdate()
    {
        HideController();
    }

    public void HideController() {
        SkeletonUIOptions skeletonUiOptions = GetComponent<SkeletonUIOptions>();
        skeletonUiOptions.HideController();
        skeletonUiOptions.AnimateHandWithoutController();
    }
}