using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerManager : MonoBehaviour
{
    [SerializeField]
    GameObject XRRig;

    [SerializeField]
    InputActionProperty LeftRotateController;
    [SerializeField]
    InputActionProperty RightRotateController;

    [SerializeField]
    InputActionProperty RightMoveController;
    [SerializeField]
    InputActionProperty LeftMoveController;

    [SerializeField]
    bool EnableLeftTele;
    [SerializeField]
    GameObject LeftTeleportController;
    [SerializeField]
    GameObject LeftControllerParent;

    [SerializeField]
    bool EnableRightTele;
    [SerializeField]
    GameObject RightTeleportController;
    [SerializeField]
    GameObject RightControllerParent;
    

    ActionBasedContinuousMoveProvider moveProvider;
    ActionBasedContinuousTurnProvider turnProvider;
    
    void Start()
    {
        moveProvider = XRRig.gameObject.GetComponent<ActionBasedContinuousMoveProvider>();
        turnProvider = XRRig.gameObject.GetComponent<ActionBasedContinuousTurnProvider>();
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("I am collided");
        if(other.gameObject.layer ==  9 ) /*9 == Interactable*/ {
            Debug.Log(this.gameObject.name);

            LeftTeleportController.SetActive(EnableLeftTele);
            LeftControllerParent.GetComponent<ActionBasedControllerManager>().enabled = EnableLeftTele;

            RightTeleportController.SetActive(EnableRightTele);
            RightControllerParent.GetComponent<ActionBasedControllerManager>().enabled = EnableRightTele;

            moveProvider.rightHandMoveAction = RightMoveController;
            moveProvider.leftHandMoveAction = LeftMoveController;

            turnProvider.rightHandTurnAction = RightRotateController;
            turnProvider.leftHandTurnAction = LeftRotateController;

        }
    }
}
