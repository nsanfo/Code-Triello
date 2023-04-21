using System.Collections;
using System;
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
    GameObject LeftTeleportController;
    [SerializeField]
    GameObject LeftControllerParent;
    [SerializeField]
    GameObject RightTeleportController;
    [SerializeField]
    GameObject RightControllerParent;

    [SerializeField]
    InputActionProperty MoveController;
    [SerializeField]
    InputActionProperty RotateController;
    

    ActionBasedContinuousMoveProvider moveProvider;
    ActionBasedContinuousTurnProvider turnProvider;
    
    void Start()
    {
        moveProvider = XRRig.gameObject.GetComponent<ActionBasedContinuousMoveProvider>();
        turnProvider = XRRig.gameObject.GetComponent<ActionBasedContinuousTurnProvider>();

        moveProvider.rightHandMoveAction = new InputActionProperty();
        moveProvider.leftHandMoveAction = moveProvider.leftHandMoveAction;
        turnProvider.rightHandTurnAction = turnProvider.rightHandTurnAction;
        turnProvider.leftHandTurnAction = new InputActionProperty();

    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log("I am collided");
        if(other.gameObject.layer ==  9 ) /*9 == Interactable*/ {
            Debug.Log(this.gameObject.name);
            Tuple<InputActionProperty, InputActionProperty> Inputs;

            moveProvider.rightHandMoveAction = new InputActionProperty();
            turnProvider.leftHandTurnAction = new InputActionProperty();
            moveProvider.leftHandMoveAction = new InputActionProperty();
            turnProvider.rightHandTurnAction = new InputActionProperty();
            

            if(this.gameObject.name == "HandL") {
                Inputs = ChangeLocomotionController(true);

                moveProvider.rightHandMoveAction = Inputs.Item1;
                turnProvider.leftHandTurnAction = Inputs.Item2;

            }else if(this.gameObject.name == "HandR") {
                Inputs = ChangeLocomotionController(false);

                moveProvider.leftHandMoveAction = Inputs.Item1;
                turnProvider.rightHandTurnAction = Inputs.Item2;
            }
 
        }
    }
    private Tuple<InputActionProperty, InputActionProperty> ChangeLocomotionController(bool CanAlternate) {
        LeftTeleportController.SetActive(!CanAlternate);
        LeftControllerParent.GetComponent<ActionBasedControllerManager>().enabled = !CanAlternate;

        RightTeleportController.SetActive(CanAlternate);
        RightControllerParent.GetComponent<ActionBasedControllerManager>().enabled = CanAlternate;

        return new Tuple<InputActionProperty, InputActionProperty>(MoveController, RotateController);

    }
}
