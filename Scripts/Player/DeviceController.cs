using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class DeviceController : MonoBehaviour
{
    public static InputDevice leftHandDevice;
    private static InputDeviceCharacteristics leftHandCharacteristic = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left;

    public static InputDevice rightHandDevice;
    private static InputDeviceCharacteristics rightHandCharacteristic = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right;


    public static Vector2 leftHandPrimary2DAxisValue;
    public static float leftHandTriggerValue;
    public static float leftHandGripValue;

    public static bool leftHandGripButtonValue;
    public static bool leftHandTriggerButtonValue;
    public static bool leftHandPrimaryButtonValue; // x
    public static bool leftHandSecondaryButtonValue; // y
    public static bool leftHandThumbStickClickValue;
    public static bool leftHandMenuButtonValue;

    public static bool leftHandPrimaryTouchValue;
    public static bool leftHandSecondaryTouchValue;
    public static bool leftHandPrimary2DAxisTouchValue;

    public static bool prev_leftHandGripButtonValue;
    public static bool prev_leftHandTriggerButtonValue;
    public static bool prev_leftHandPrimaryButtonValue; // x
    public static bool prev_leftHandSecondaryButtonValue; // y
    public static bool prev_leftHandThumbStickClickValue;
    public static bool prev_leftHandMenuButtonValue;

    public static bool prev_leftHandPrimaryTouchValue;
    public static bool prev_leftHandSecondaryTouchValue;
    public static bool prev_leftHandPrimary2DAxisTouchValue;


    public static Vector2 rightHandPrimary2DAxisValue;
    public static float rightHandTriggerValue;
    public static float rightHandGripValue;

    public static bool rightHandGripButtonValue;
    public static bool rightHandTriggerButtonValue;
    public static bool rightHandPrimaryButtonValue; // a
    public static bool rightHandSecondaryButtonValue; // b
    public static bool rightHandThumbStickClickValue;

    public static bool rightHandPrimaryTouchValue;
    public static bool rightHandSecondaryTouchValue;
    public static bool rightHandPrimary2DAxisTouchValue;

    public static bool prev_rightHandGripButtonValue;
    public static bool prev_rightHandTriggerButtonValue;
    public static bool prev_rightHandPrimaryButtonValue; // a
    public static bool prev_rightHandSecondaryButtonValue; // b
    public static bool prev_rightHandThumbStickClickValue;

    public static bool prev_rightHandPrimaryTouchValue;
    public static bool prev_rightHandSecondaryTouchValue;
    public static bool prev_rightHandPrimary2DAxisTouchValue;



    //  =============================== //
    //               AWAKE              //
    //  =============================== //
    private void Awake() {
        // Called once, before any Start() method


        // Try to initialize left and right controller
        List<InputDevice> leftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1) {
            leftHandDevice = leftHandDevices[0];
            InitializeLeft();
            updateLeftHand();
        } else if (leftHandDevices.Count > 1) {
            Debug.Log("Found more than one left hand!");
        } else {
            Debug.Log("No left hand found!");
        }

        List<InputDevice> rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);

        if (rightHandDevices.Count == 1) {
            rightHandDevice = rightHandDevices[0];
            InitializeRight();
            updateRightHand();
        } else if (rightHandDevices.Count > 1) {
            Debug.Log("Found more than one right hand!");
        } else {
            Debug.Log("No right hand found!");
        }


        // Set up listener for controller connect / disconnect
        InputDevices.deviceConnected += ControllerConnected;
        InputDevices.deviceDisconnected += ControllerDisconnected;
    }



    //  =============================== //
    //          INITIALIZE LEFT         //
    //  =============================== //
    public void InitializeLeft() {
        prev_leftHandGripButtonValue = false;
        prev_leftHandTriggerButtonValue = false;
        prev_leftHandPrimaryButtonValue = false; // x
        prev_leftHandSecondaryButtonValue = false; // y
        prev_leftHandThumbStickClickValue = false;
        prev_leftHandMenuButtonValue = false;

        prev_leftHandPrimaryTouchValue = true;
        prev_leftHandSecondaryTouchValue = false;
        prev_leftHandPrimary2DAxisTouchValue = false;
    }



    //  =============================== //
    //         INITIALIZE Right         //
    //  =============================== //
    public void InitializeRight() {
        prev_rightHandGripButtonValue = false;
        prev_rightHandTriggerButtonValue = false;
        prev_rightHandPrimaryButtonValue = false; // x
        prev_rightHandSecondaryButtonValue = false; // y
        prev_rightHandThumbStickClickValue = false;

        prev_rightHandPrimaryTouchValue = true;
        prev_rightHandSecondaryTouchValue = false;
        prev_rightHandPrimary2DAxisTouchValue = false;
    }



    //  =============================== //
    //              UPDATE              //
    //  =============================== //
    public void Update() {
        // Game update script
        updateLeftHand();
        updateRightHand();
    }



    //  =============================== //
    //          UPDATE LEFT HAND        //
    //  =============================== //
    public void updateLeftHand() {


        if (leftHandDevice.isValid) {
            // AXIS
            if (leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out leftHandPrimary2DAxisValue) && (((float)Math.Round(leftHandPrimary2DAxisValue.x * 10000f) / 10000f) != 0.0 || ((float)Math.Round(leftHandPrimary2DAxisValue.y * 10000f) / 10000f) != 0.0)) {
                // axis value
                Debug.Log("leftHand - primary2DAxisValue: (" + leftHandPrimary2DAxisValue.x.ToString("0.0000") + ") , (" + leftHandPrimary2DAxisValue.y.ToString("0.0000") + ")");
            }

            if (leftHandDevice.TryGetFeatureValue(CommonUsages.trigger, out leftHandTriggerValue) && ((float)Math.Round(leftHandTriggerValue * 10000f) / 10000f) != 0.0) {
                // axis value
                Debug.Log("leftHand - triggerValue: " + leftHandTriggerValue.ToString("0.0000"));
            }

            if (leftHandDevice.TryGetFeatureValue(CommonUsages.grip, out leftHandGripValue) && ((float)Math.Round(leftHandGripValue * 10000f) / 10000f) != 0.0) {
                // axis value
                Debug.Log("leftHand - gripValue: " + leftHandGripValue.ToString("0.0000"));
            }


            // BUTTONS
            if (leftHandDevice.TryGetFeatureValue(CommonUsages.gripButton, out leftHandGripButtonValue) && leftHandGripButtonValue) {
                // button is pressed
                if (prev_leftHandGripButtonValue != leftHandGripButtonValue) {
                    // invoke left grip event

                    prev_leftHandGripButtonValue = true;
                    EventManager.TriggerEvent("leftHandGripPressAnimationEventMethod");
                }

                Debug.Log("leftHand - gripButtonValue: " + leftHandGripButtonValue);
            } else {
                if (prev_leftHandGripButtonValue != leftHandGripButtonValue) {
                    EventManager.TriggerEvent("leftHandGripReleaseAnimationEventMethod");
                    prev_leftHandGripButtonValue = false;
                }
            }

            if (leftHandDevice.TryGetFeatureValue(CommonUsages.triggerButton, out leftHandTriggerButtonValue) && leftHandTriggerButtonValue) {
                // button is pressed
                if (prev_leftHandTriggerButtonValue != leftHandTriggerButtonValue) {
                    // invoke left trigger event
                    prev_leftHandTriggerButtonValue = true;
                    EventManager.TriggerEvent("leftHandTriggerPressAnimationEventMethod");
                }

                Debug.Log("leftHand - prev_leftHandTriggerButtonValue: " + prev_leftHandTriggerButtonValue);
                Debug.Log("leftHand - leftHandTriggerButtonValue: " + leftHandTriggerButtonValue);
                Debug.Log("leftHand - triggerButtonValue: " + leftHandTriggerButtonValue);
            } else {
                Debug.Log("leftHand - prev_leftHandTriggerButtonValue: " + prev_leftHandTriggerButtonValue);
                if (prev_leftHandTriggerButtonValue != leftHandTriggerButtonValue) {
                    EventManager.TriggerEvent("leftHandTriggerReleaseAnimationEventMethod");
                    prev_leftHandTriggerButtonValue = false;
                }
            }


            if (leftHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out leftHandPrimaryButtonValue) && leftHandPrimaryButtonValue) {
                // button is pressed
                if (prev_leftHandPrimaryButtonValue != leftHandPrimaryButtonValue) {
                    // invoke left thumb rest event

                    prev_leftHandPrimaryButtonValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - primaryButtonValue: " + leftHandPrimaryButtonValue);
            } else {
                if (prev_leftHandPrimaryButtonValue != leftHandPrimaryButtonValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    prev_leftHandPrimaryButtonValue = false;
                }
            }

            if (leftHandDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out leftHandSecondaryButtonValue) && leftHandSecondaryButtonValue) {
                // button is pressed
                if (prev_leftHandSecondaryButtonValue != leftHandSecondaryButtonValue) {
                    // invoke left thumb rest event

                    prev_leftHandSecondaryButtonValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - primaryButtonValue: " + leftHandSecondaryButtonValue);
            } else {
                if (prev_leftHandSecondaryButtonValue != leftHandSecondaryButtonValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    prev_leftHandSecondaryButtonValue = false;
                }
            }

            if (leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out leftHandThumbStickClickValue) && leftHandThumbStickClickValue) {
                // button is pressed
                if (prev_leftHandThumbStickClickValue != leftHandThumbStickClickValue) {
                    // invoke left thumb rest event

                    prev_leftHandThumbStickClickValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - thumbStickClickValue: " + leftHandThumbStickClickValue);
            } else {
                if (prev_leftHandThumbStickClickValue != leftHandThumbStickClickValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    prev_leftHandThumbStickClickValue = false;
                }
            }

            if (leftHandDevice.TryGetFeatureValue(CommonUsages.menuButton, out leftHandMenuButtonValue) && leftHandMenuButtonValue) {
                // button is pressed
                if (prev_leftHandMenuButtonValue != leftHandMenuButtonValue) {
                    prev_leftHandMenuButtonValue = true;
                }

                Debug.Log("leftHand - menuButtonValue: " + leftHandMenuButtonValue);
            } else {
                if (prev_leftHandMenuButtonValue != leftHandMenuButtonValue) {
                    prev_leftHandMenuButtonValue = false;
                }
            }


            // TOUCH
            if (leftHandDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out leftHandPrimaryTouchValue) && leftHandPrimaryTouchValue) {
                // button is touched
                if (prev_leftHandPrimaryTouchValue != leftHandPrimaryTouchValue) {
                    // invoke left thumb rest event

                    prev_leftHandPrimaryTouchValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - primaryTouchValue: " + leftHandPrimaryTouchValue);
            } else {
                if (prev_leftHandPrimaryTouchValue != leftHandPrimaryTouchValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    prev_leftHandPrimaryTouchValue = false;
                }
            }

            if (leftHandDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out leftHandSecondaryTouchValue) && leftHandSecondaryTouchValue) {
                // button is touched
                if (prev_leftHandSecondaryTouchValue != leftHandSecondaryTouchValue) {
                    // invoke left thumb rest event

                    prev_leftHandSecondaryTouchValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - secondaryTouchValue: " + leftHandSecondaryTouchValue);
            } else {
                if (prev_leftHandSecondaryTouchValue != leftHandSecondaryTouchValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    prev_leftHandSecondaryTouchValue = false;
                }
            }

            if (leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out leftHandPrimary2DAxisTouchValue) && leftHandPrimary2DAxisTouchValue) {
                // button is touched
                if (prev_leftHandPrimary2DAxisTouchValue != leftHandPrimary2DAxisTouchValue) {
                    // invoke left grip event

                    prev_leftHandPrimary2DAxisTouchValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - primary2DAxisTouchValue: " + leftHandPrimary2DAxisTouchValue);
            } else {
                if (prev_leftHandPrimary2DAxisTouchValue != leftHandPrimary2DAxisTouchValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    prev_leftHandPrimary2DAxisTouchValue = false;
                }
            }
        }
    }



    //  =============================== //
    //          UPDATE RIGHT HAND       //
    //  =============================== //
    public void updateRightHand() {
        if (rightHandDevice.isValid) {
            // AXIS
            if (rightHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out rightHandPrimary2DAxisValue) && (((float)Math.Round(rightHandPrimary2DAxisValue.x * 10000f) / 10000f) != 0.0 || ((float)Math.Round(rightHandPrimary2DAxisValue.y * 10000f) / 10000f) != 0.0)) {
                // axis value
                Debug.Log("rightHand - primary2DAxisValue: (" + rightHandPrimary2DAxisValue.x.ToString("0.0000") + ") , (" + rightHandPrimary2DAxisValue.y.ToString("0.0000") + ")");
            }

            if (rightHandDevice.TryGetFeatureValue(CommonUsages.trigger, out rightHandTriggerValue) && ((float)Math.Round(rightHandTriggerValue * 10000f) / 10000f) != 0.0) {
                // axis value
                Debug.Log("rightHand - triggerValue: " + rightHandTriggerValue.ToString("0.0000"));
            }

            if (rightHandDevice.TryGetFeatureValue(CommonUsages.grip, out rightHandGripValue) && ((float)Math.Round(rightHandGripValue * 10000f) / 10000f) != 0.0) {
                // axis value
                Debug.Log("rightHand - gripValue: " + rightHandGripValue.ToString("0.0000"));
            }


            // BUTTONS
            if (rightHandDevice.TryGetFeatureValue(CommonUsages.gripButton, out rightHandGripButtonValue) && rightHandGripButtonValue) {
                // button is pressed
                if (prev_rightHandGripButtonValue != rightHandGripButtonValue) {
                    // invoke right grip event

                    prev_rightHandGripButtonValue = true;
                    EventManager.TriggerEvent("rightHandGripPressAnimationEventMethod");
                }

                Debug.Log("rightHand - gripButtonValue: " + rightHandGripButtonValue);
            } else {
                if (prev_rightHandGripButtonValue != rightHandGripButtonValue) {
                    EventManager.TriggerEvent("rightHandGripReleaseAnimationEventMethod");
                    prev_rightHandGripButtonValue = false;
                }
            }

            if (rightHandDevice.TryGetFeatureValue(CommonUsages.triggerButton, out rightHandTriggerButtonValue) && rightHandTriggerButtonValue) {
                // button is pressed
                if (prev_rightHandTriggerButtonValue != rightHandTriggerButtonValue) {
                    // invoke right trigger event

                    prev_rightHandTriggerButtonValue = true;
                    EventManager.TriggerEvent("rightHandTriggerPressAnimationEventMethod");
                }

                Debug.Log("rightHand - triggerButtonValue: " + rightHandTriggerButtonValue);
            } else {
                if (prev_rightHandTriggerButtonValue != rightHandTriggerButtonValue) {
                    EventManager.TriggerEvent("rightHandTriggerReleaseAnimationEventMethod");
                    prev_rightHandTriggerButtonValue = false;
                }
            }

            if (rightHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out rightHandPrimaryButtonValue) && rightHandPrimaryButtonValue) {
                // button is pressed
                if (prev_rightHandPrimaryButtonValue != rightHandPrimaryButtonValue) {
                    // invoke right thumb rest event

                    prev_rightHandPrimaryButtonValue = true;
                    EventManager.TriggerEvent("rightHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("rightHand - primaryButtonValue: " + rightHandPrimaryButtonValue);
            } else {
                if (prev_rightHandPrimaryButtonValue != rightHandPrimaryButtonValue) {
                    EventManager.TriggerEvent("rightHandThumbRestReleaseAnimationEventMethod");
                    prev_rightHandPrimaryButtonValue = false;
                }
            }

            if (rightHandDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out rightHandSecondaryButtonValue) && rightHandSecondaryButtonValue) {
                // button is pressed
                if (prev_rightHandSecondaryButtonValue != rightHandSecondaryButtonValue) {
                    // invoke right thumb rest event

                    prev_rightHandSecondaryButtonValue = true;
                    EventManager.TriggerEvent("rightHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("rightHand - secondaryButtonValue: " + rightHandSecondaryButtonValue);
            } else {
                if (prev_rightHandSecondaryButtonValue != rightHandSecondaryButtonValue) {
                    EventManager.TriggerEvent("rightHandThumbRestReleaseAnimationEventMethod");
                    prev_rightHandSecondaryButtonValue = false;
                }
            }

            if (rightHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out rightHandThumbStickClickValue) && rightHandThumbStickClickValue) {
                // button is pressed
                if (prev_rightHandThumbStickClickValue != rightHandThumbStickClickValue) {
                    // invoke right thumb rest event

                    prev_rightHandThumbStickClickValue = true;
                    EventManager.TriggerEvent("rightHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("rightHand - thumbStickClickValue: " + rightHandThumbStickClickValue);
            } else {
                if (prev_rightHandThumbStickClickValue != rightHandThumbStickClickValue) {
                    EventManager.TriggerEvent("rightHandThumbRestReleaseAnimationEventMethod");
                    prev_rightHandThumbStickClickValue = false;
                }
            }


            // TOUCH
            if (rightHandDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out rightHandPrimaryTouchValue) && rightHandPrimaryTouchValue) {
                // button is touched
                if (prev_rightHandPrimaryTouchValue != rightHandPrimaryTouchValue) {
                    // invoke right thumb rest event

                    prev_rightHandPrimaryTouchValue = true;
                    EventManager.TriggerEvent("rightHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("rightHand - primaryTouchValue: " + rightHandPrimaryTouchValue);
            } else {
                if (prev_rightHandPrimaryTouchValue != rightHandPrimaryTouchValue) {
                    EventManager.TriggerEvent("rightHandThumbRestReleaseAnimationEventMethod");
                    prev_rightHandPrimaryTouchValue = false;
                }
            }

            if (rightHandDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out rightHandSecondaryTouchValue) && rightHandSecondaryTouchValue) {
                // button is touched
                if (prev_rightHandSecondaryTouchValue != rightHandSecondaryTouchValue) {
                    // invoke right thumb rest event

                    prev_rightHandSecondaryTouchValue = true;
                    EventManager.TriggerEvent("rightHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("rightHand - secondaryTouchValue: " + rightHandSecondaryTouchValue);
            } else {
                if (prev_rightHandSecondaryTouchValue != rightHandSecondaryTouchValue) {
                    EventManager.TriggerEvent("rightHandThumbRestReleaseAnimationEventMethod");
                    prev_rightHandSecondaryTouchValue = false;
                }
            }

            if (rightHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out rightHandPrimary2DAxisTouchValue) && rightHandPrimary2DAxisTouchValue) {
                // button is touched
                if (prev_rightHandPrimary2DAxisTouchValue != rightHandPrimary2DAxisTouchValue) {
                    // invoke right thumb rest event

                    prev_rightHandPrimary2DAxisTouchValue = true;
                    EventManager.TriggerEvent("rightHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("rightHand - primary2DAxisTouchValue: " + rightHandPrimary2DAxisTouchValue);
            } else {
                if (prev_rightHandPrimary2DAxisTouchValue != rightHandPrimary2DAxisTouchValue) {
                    EventManager.TriggerEvent("rightHandThumbRestReleaseAnimationEventMethod");
                    prev_rightHandPrimary2DAxisTouchValue = false;
                }
            }
        }
    }


    //  =============================== //
    //       CONTROLLER CONNECTED       //
    //  =============================== //
    private void ControllerConnected(InputDevice device) {

        if (device.characteristics.Equals(leftHandCharacteristic)) {
            Debug.Log("Left controller connected");
            leftHandDevice = device;
            InitializeLeft();
            updateLeftHand();
        }

        if (device.characteristics.Equals(rightHandCharacteristic)) {
            Debug.Log("Right controller connected");
            rightHandDevice = device;
            InitializeRight();
            updateRightHand();
        }
    }



    //  =============================== //
    //     CONTROLLER DISCONNECTED      //
    //  =============================== //
    private void ControllerDisconnected(InputDevice device) {

        if (device.characteristics.Equals(leftHandCharacteristic)) {
            Debug.Log("Left controller disconnected");
        }

        if (device.characteristics.Equals(rightHandCharacteristic)) {
            Debug.Log("Right controller disconnected");
        }
    }



    //  =============================== //
    //              ON DESTROY          //
    //  =============================== //
    private void OnDestroy() {
        InputDevices.deviceConnected -= ControllerConnected;
        InputDevices.deviceDisconnected -= ControllerDisconnected;
    }
}
