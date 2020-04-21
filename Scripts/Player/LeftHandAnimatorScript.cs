using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandAnimatorScript : MonoBehaviour {

    Animator anim;

    // Start is called before the first frame update
    void Awake() {
        anim = GetComponent<Animator>();

        EventManager.StartListening("leftHandTriggerPressAnimationEventMethod", leftHandTriggerPressAnimationEvent);
        EventManager.StartListening("leftHandTriggerReleaseAnimationEventMethod", leftHandTriggerReleaseAnimationEvent);
        EventManager.StartListening("leftHandGripPressAnimationEventMethod", leftHandGripPressAnimationEvent);
        EventManager.StartListening("leftHandGripReleaseAnimationEventMethod", leftHandGripReleaseAnimationEvent);
        EventManager.StartListening("leftHandThumbRestPressAnimationEventMethod", leftHandThumbRestPressAnimationEvent);
        EventManager.StartListening("leftHandThumbRestReleaseAnimationEventMethod", leftHandThumbRestReleaseAnimationEvent);
    }

    // Update is called once per frame
    void Update() {

    }

    public void leftHandTriggerPressAnimationEvent() {
        Debug.Log("WAWAWA");
        anim.SetBool("trigger", true);
    }

    public void leftHandTriggerReleaseAnimationEvent() {
        anim.SetBool("trigger", false);
    }

    public void leftHandGripPressAnimationEvent() {
        anim.SetBool("grip", true);
    }

    public void leftHandGripReleaseAnimationEvent() {
        anim.SetBool("grip", false);
    }

    public void leftHandThumbRestPressAnimationEvent() {
        anim.SetBool("thumbRest", true);
    }

    public void leftHandThumbRestReleaseAnimationEvent() {
        anim.SetBool("thumbRest", false);
    }



    //  =============================== //
    //              ON DESTROY          //
    //  =============================== //
    private void OnDestroy() {
        EventManager.StopListening("leftHandTriggerPressAnimationEventMethod", leftHandTriggerPressAnimationEvent);
        EventManager.StopListening("leftHandTriggerReleaseAnimationEventMethod", leftHandTriggerReleaseAnimationEvent);
        EventManager.StopListening("leftHandGripPressAnimationEventMethod", leftHandGripPressAnimationEvent);
        EventManager.StopListening("leftHandGripReleaseAnimationEventMethod", leftHandGripReleaseAnimationEvent);
        EventManager.StopListening("leftHandThumbRestPressAnimationEventMethod", leftHandThumbRestPressAnimationEvent);
        EventManager.StopListening("leftHandThumbRestReleaseAnimationEvent", leftHandThumbRestReleaseAnimationEvent);
    }
}