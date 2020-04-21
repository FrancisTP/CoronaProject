using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class HandPoseScript : MonoBehaviour {

    //  =============================== //
    //               AWAKE              //
    //  =============================== //
    private void Awake() {
        // Called once, before any Start() method
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


        if (DeviceController.leftHandDevice.isValid) {
            // AXIS
            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out DeviceController.leftHandPrimary2DAxisValue) && (((float)Math.Round(DeviceController.leftHandPrimary2DAxisValue.x * 10000f) / 10000f) != 0.0 || ((float)Math.Round(DeviceController.leftHandPrimary2DAxisValue.y * 10000f) / 10000f) != 0.0)) {
                // axis value
                Debug.Log("leftHand - primary2DAxisValue: (" + DeviceController.leftHandPrimary2DAxisValue.x.ToString("0.0000") + ") , (" + DeviceController.leftHandPrimary2DAxisValue.y.ToString("0.0000") + ")");
            }

            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.trigger, out DeviceController.leftHandTriggerValue) && ((float)Math.Round(DeviceController.leftHandTriggerValue * 10000f) / 10000f) != 0.0) {
                // axis value
                Debug.Log("leftHand - triggerValue: " + DeviceController.leftHandTriggerValue.ToString("0.0000"));
            }

            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.grip, out DeviceController.leftHandGripValue) && ((float)Math.Round(DeviceController.leftHandGripValue * 10000f) / 10000f) != 0.0) {
                // axis value
                Debug.Log("leftHand - gripValue: " + DeviceController.leftHandGripValue.ToString("0.0000"));
            }


            // BUTTONS
            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.gripButton, out DeviceController.leftHandGripButtonValue) && DeviceController.leftHandGripButtonValue) {
                // button is pressed
                if (DeviceController.prev_leftHandGripButtonValue != DeviceController.leftHandGripButtonValue) {
                    // invoke left grip event

                    DeviceController.prev_leftHandGripButtonValue = true;
                    EventManager.TriggerEvent("leftHandGripPressAnimationEventMethod");
                }

                Debug.Log("leftHand - gripButtonValue: " + DeviceController.leftHandGripButtonValue);
            } else {
                if (DeviceController.prev_leftHandGripButtonValue != DeviceController.leftHandGripButtonValue) {
                    EventManager.TriggerEvent("leftHandGripReleaseAnimationEventMethod");
                    DeviceController.prev_leftHandGripButtonValue = false;
                }
            }

            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.triggerButton, out DeviceController.leftHandTriggerButtonValue) && DeviceController.leftHandTriggerButtonValue) {
                // button is pressed
                if (DeviceController.prev_leftHandTriggerButtonValue != DeviceController.leftHandTriggerButtonValue) {
                    // invoke left trigger event
                    DeviceController.prev_leftHandTriggerButtonValue = true;
                    EventManager.TriggerEvent("leftHandTriggerPressAnimationEventMethod");
                }

                Debug.Log("leftHand - prev_leftHandTriggerButtonValue: " + DeviceController.prev_leftHandTriggerButtonValue);
                Debug.Log("leftHand - leftHandTriggerButtonValue: " + DeviceController.leftHandTriggerButtonValue);
                Debug.Log("leftHand - triggerButtonValue: " + DeviceController.leftHandTriggerButtonValue);
            } else {
                Debug.Log("leftHand - prev_leftHandTriggerButtonValue: " + DeviceController.prev_leftHandTriggerButtonValue);
                if (DeviceController.prev_leftHandTriggerButtonValue != DeviceController.leftHandTriggerButtonValue) {
                    EventManager.TriggerEvent("leftHandTriggerReleaseAnimationEventMethod");
                    DeviceController.prev_leftHandTriggerButtonValue = false;
                }
            }


            if (leftHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out DeviceController.leftHandPrimaryButtonValue) && DeviceController.leftHandPrimaryButtonValue) {
                // button is pressed
                if (DeviceController.prev_leftHandPrimaryButtonValue != DeviceController.leftHandPrimaryButtonValue) {
                    // invoke left thumb rest event

                    DeviceController.prev_leftHandPrimaryButtonValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - primaryButtonValue: " + DeviceController.leftHandPrimaryButtonValue);
            } else {
                if (DeviceController.prev_leftHandPrimaryButtonValue != DeviceController.leftHandPrimaryButtonValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    DeviceController.prev_leftHandPrimaryButtonValue = false;
                }
            }

            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out DeviceController.leftHandSecondaryButtonValue) && DeviceController.leftHandSecondaryButtonValue) {
                // button is pressed
                if (DeviceController.prev_leftHandSecondaryButtonValue != DeviceController.leftHandSecondaryButtonValue) {
                    // invoke left thumb rest event

                    DeviceController.prev_leftHandSecondaryButtonValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod") ;
                }

                Debug.Log("leftHand - primaryButtonValue: " + DeviceController.leftHandSecondaryButtonValue);
            } else {
                if (DeviceController.prev_leftHandSecondaryButtonValue != DeviceController.leftHandSecondaryButtonValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    DeviceController.prev_leftHandSecondaryButtonValue = false;
                }
            }

            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out DeviceController.leftHandThumbStickClickValue) && DeviceController.leftHandThumbStickClickValue) {
                // button is pressed
                if (DeviceController.prev_leftHandThumbStickClickValue != DeviceController.leftHandThumbStickClickValue) {
                    // invoke left thumb rest event

                    DeviceController.prev_leftHandThumbStickClickValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - thumbStickClickValue: " + DeviceController.leftHandThumbStickClickValue);
            } else {
                if (DeviceController.prev_leftHandThumbStickClickValue != DeviceController.leftHandThumbStickClickValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    DeviceController.prev_leftHandThumbStickClickValue = false;
                }
            }

            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.menuButton, out DeviceController.leftHandMenuButtonValue) && DeviceController.leftHandMenuButtonValue) {
                // button is pressed
                if (DeviceController.prev_leftHandMenuButtonValue != DeviceController.leftHandMenuButtonValue) {
                    DeviceController.prev_leftHandMenuButtonValue = true;
                }

                Debug.Log("leftHand - menuButtonValue: " + DeviceController.leftHandMenuButtonValue);
            } else {
                if (DeviceController.prev_leftHandMenuButtonValue != DeviceController.leftHandMenuButtonValue) {
                    DeviceController.prev_leftHandMenuButtonValue = false;
                }
            }


            // TOUCH
            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out DeviceController.leftHandPrimaryTouchValue) && DeviceController.leftHandPrimaryTouchValue) {
                // button is touched
                if (DeviceController.prev_leftHandPrimaryTouchValue != DeviceController.leftHandPrimaryTouchValue) {
                    // invoke left thumb rest event

                    DeviceController.prev_leftHandPrimaryTouchValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - primaryTouchValue: " + DeviceController.leftHandPrimaryTouchValue);
            } else {
                if (DeviceController.prev_leftHandPrimaryTouchValue != DeviceController.leftHandPrimaryTouchValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    DeviceController.prev_leftHandPrimaryTouchValue = false;
                }
            }

            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out DeviceController.leftHandSecondaryTouchValue) && DeviceController.leftHandSecondaryTouchValue) {
                // button is touched
                if (DeviceController.prev_leftHandSecondaryTouchValue != DeviceController.leftHandSecondaryTouchValue) {
                    // invoke left thumb rest event

                    DeviceController.prev_leftHandSecondaryTouchValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - secondaryTouchValue: " + DeviceController.leftHandSecondaryTouchValue);
            } else {
                if (DeviceController.prev_leftHandSecondaryTouchValue != DeviceController.leftHandSecondaryTouchValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    DeviceController.prev_leftHandSecondaryTouchValue = false;
                }
            }

            if (DeviceController.leftHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out DeviceController.leftHandPrimary2DAxisTouchValue) && DeviceController.leftHandPrimary2DAxisTouchValue) {
                // button is touched
                if (DeviceController.prev_leftHandPrimary2DAxisTouchValue != DeviceController.leftHandPrimary2DAxisTouchValue) {
                    // invoke left grip event

                    DeviceController.prev_leftHandPrimary2DAxisTouchValue = true;
                    EventManager.TriggerEvent("leftHandThumbRestPressAnimationEventMethod");
                }

                Debug.Log("leftHand - primary2DAxisTouchValue: " + DeviceController.leftHandPrimary2DAxisTouchValue);
            } else {
                if (DeviceController.prev_leftHandPrimary2DAxisTouchValue != DeviceController.leftHandPrimary2DAxisTouchValue) {
                    EventManager.TriggerEvent("leftHandThumbRestReleaseAnimationEventMethod");
                    DeviceController.prev_leftHandPrimary2DAxisTouchValue = false;
                }
            }
        }
    }



    //  =============================== //
    //          UPDATE RIGHT HAND       //
    //  =============================== //
    public void updateRightHand() {
        if (DeviceController.rightHandDevice.isValid) {
            // AXIS
            if (DeviceController.rightHandDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out DeviceController.rightHandPrimary2DAxisValue) && (((float)Math.Round(DeviceController.rightHandPrimary2DAxisValue.x * 10000f) / 10000f) != 0.0 || ((float)Math.Round(DeviceController.rightHandPrimary2DAxisValue.y * 10000f) / 10000f) != 0.0)) {
                // axis value
                Debug.Log("rightHand - primary2DAxisValue: (" + DeviceController.rightHandPrimary2DAxisValue.x.ToString("0.0000") + ") , (" + DeviceController.rightHandPrimary2DAxisValue.y.ToString("0.0000") + ")");
            }

            if (DeviceController.rightHandDevice.TryGetFeatureValue(CommonUsages.trigger, out DeviceController.rightHandTriggerValue) && ((float)Math.Round(DeviceController.rightHandTriggerValue * 10000f) / 10000f) != 0.0) {
                // axis value
                Debug.Log("rightHand - triggerValue: " + DeviceController.rightHandTriggerValue.ToString("0.0000"));
            }

            if (DeviceController.rightHandDevice.TryGetFeatureValue(CommonUsages.grip, out DeviceController.rightHandGripValue) && ((float)Math.Round(DeviceController.rightHandGripValue * 10000f) / 10000f) != 0.0) {
                // axis value
                Debug.Log("rightHand - gripValue: " + DeviceController.rightHandGripValue.ToString("0.0000"));
            }


            // BUTTONS
            if (DeviceController.rightHandDevice.TryGetFeatureValue(CommonUsages.gripButton, out DeviceController.rightHandGripButtonValue) && DeviceController.rightHandGripButtonValue) {
                // button is pressed
                if (DeviceController.prev_rightHandGripButtonValue != DeviceController.rightHandGripButtonValue) {
                    // invoke right grip event

                    DeviceController.prev_rightHandGripButtonValue = true;
                    EventManager.TriggerEvent("rightHandGripPressAnimationEventMethod");
                }

                Debug.Log("rightHand - gripButtonValue: " + DeviceController.rightHandGripButtonValue);
            } else {
                if (DeviceController.prev_rightHandGripButtonValue != DeviceController.rightHandGripButtonValue) {
                    EventManager.TriggerEvent("rightHandGripReleaseAnimationEventMethod");
                    DeviceController.prev_rightHandGripButtonValue = false;
                }
            }

            if (rightHandDevice.TryGetFeatureValue(CommonUsages.triggerButton, out DeviceController.rightHandTriggerButtonValue) && DeviceController.rightHandTriggerButtonValue) {
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
