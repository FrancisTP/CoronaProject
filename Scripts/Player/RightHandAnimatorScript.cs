using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandAnimatorScript : MonoBehaviour
{

    Animator anim;

    // Start is called before the first frame update
    void Awake() {
        anim = GetComponent<Animator>();

        EventManager.StartListening ("rightHandTriggerPressAnimationEventMethod", rightHandTriggerPressAnimationEvent);
        EventManager.StartListening("rightHandTriggerReleaseAnimationEventMethod", rightHandTriggerReleaseAnimationEvent);
        EventManager.StartListening("rightHandGripPressAnimationEventMethod", rightHandGripPressAnimationEvent);
        EventManager.StartListening("rightHandGripReleaseAnimationEventMethod", rightHandGripReleaseAnimationEvent);
        EventManager.StartListening("rightHandThumbRestPressAnimationEventMethod", rightHandThumbRestPressAnimationEvent);
        EventManager.StartListening("rightHandThumbRestReleaseAnimationEventMethod", rightHandThumbRestReleaseAnimationEvent);
    }

    // Update is called once per frame
    void Update() {

    }

    public void rightHandTriggerPressAnimationEvent() {
        anim.SetBool("trigger", true);
    }

    public void rightHandTriggerReleaseAnimationEvent() {
        anim.SetBool("trigger", false);
    }

    public void rightHandGripPressAnimationEvent() {
        anim.SetBool("grip", true);
    }

    public void rightHandGripReleaseAnimationEvent() {
        anim.SetBool("grip", false);
    }

    public void rightHandThumbRestPressAnimationEvent() {
        anim.SetBool("thumbRest", true);
    }

    public void rightHandThumbRestReleaseAnimationEvent() {
        anim.SetBool("thumbRest", false);
    }

    //  =============================== //
    //              ON DESTROY          //
    //  =============================== //
    private void OnDestroy() {
        EventManager.StopListening("rightHandTriggerPressAnimationEventMethod", rightHandTriggerPressAnimationEvent);
        EventManager.StopListening("rightHandTriggerReleaseAnimationEvenMethod", rightHandTriggerReleaseAnimationEvent);
        EventManager.StopListening("rightHandGripPressAnimationEventMethod", rightHandGripPressAnimationEvent);
        EventManager.StopListening("rightHandGripReleaseAnimationEventMethod", rightHandGripReleaseAnimationEvent);
        EventManager.StopListening("rightHandThumbRestPressAnimationEventMethod", rightHandThumbRestPressAnimationEvent);
        EventManager.StopListening("rightHandThumbRestReleaseAnimationEventMethod", rightHandThumbRestReleaseAnimationEvent);
    }
}
