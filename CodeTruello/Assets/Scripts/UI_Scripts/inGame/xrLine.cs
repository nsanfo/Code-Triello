using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class xrLine : MonoBehaviour
{
    public LineRenderer lineVisual;

    void Start()
    {
        lineVisual.enabled = false;
    }

    public void SetLineVisualVisibility(bool isVisible)
    {
        lineVisual.enabled = isVisible;
    }
}
