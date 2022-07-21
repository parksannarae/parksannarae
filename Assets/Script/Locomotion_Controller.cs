using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Locomotion_Controller : MonoBehaviour
{

    public XRController leftTelportRay;
    public XRController rightTelportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if(leftTelportRay)
        {
            leftTelportRay.gameObject.SetActive(CheckIfActivated(leftTelportRay));
        }
        if (rightTelportRay)
        {
            rightTelportRay.gameObject.SetActive(CheckIfActivated(rightTelportRay));
        }

    }

    public bool CheckIfActivated(XRController contoller)
    {
        InputHelpers.IsPressed(contoller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }
}