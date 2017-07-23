using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class tk_listener_Grow : MonoBehaviour {

    private void Start() {
        if (GetComponent<VRTK_InteractTouch>() == null) {
            VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
            return;
        }

        GetComponent<VRTK_InteractTouch>().ControllerStartTouchInteractableObject += new ObjectInteractEventHandler(DoTouchStart);
        GetComponent<VRTK_InteractTouch>().ControllerTouchInteractableObject += new ObjectInteractEventHandler(DoTouch);
        GetComponent<VRTK_InteractTouch>().ControllerStartUntouchInteractableObject += new ObjectInteractEventHandler(DoUntouchStart);
        GetComponent<VRTK_InteractTouch>().ControllerUntouchInteractableObject += new ObjectInteractEventHandler(DoUntouch);
        
    }

    private void DoTouchStart(object sender, ObjectInteractEventArgs e) {
        e.target.transform.parent.GetComponentInChildren<Riser>().StartRise();
        //e.target.GetComponent<Riser>().StartRise();
    }

    private void DoTouch(object sender, ObjectInteractEventArgs e) {

    }

    private void DoUntouchStart(object sender, ObjectInteractEventArgs e) {

    }

    private void DoUntouch(object sender, ObjectInteractEventArgs e) {
        e.target.transform.parent.GetComponentInChildren<Riser>().EndRise();
        //e.target.GetComponent<Riser>().StartRise();
    }

}
